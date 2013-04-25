// Các hàm jQuery mở rộng để xử dụng
// Copyright: Lê Cao Minh Thành

; (function ($) {

    //Trạng thái của View, tham khảo trong CommonMessage
    var formState;
    EnabledInputs(false);

    // Function sự kiện của Toolbar (phải khai báo cho giống)
    function ToolbarCommand(command) {
        //command: trả về command của Toolbar khi click, command lấy trong CommonMessage
        switch (command) {
            case "@CommonMessage.TOOLBARITEM_CREATE":
                // Chuyển trạng thái View sang Edit
                formState = "@CommonMessage.STATE_NEW";

                // Enable tất cả control
                EnabledInputs(true);

                // Xóa trắng tất cả Input
                ClearAllInput("FormEdit");

                // Focus Input đầu tiên
                FocusFirstInput();
                break;
            case "@CommonMessage.TOOLBARITEM_EDIT":
                // Chuyển trạng thái View sang Edit
                formState = "@CommonMessage.STATE_EDIT";

                // Enable tất cả control
                EnabledInputs(true);

                // Focus Input đầu tiên
                FocusFirstInput();
                break;
            case "@CommonMessage.TOOLBARITEM_CANCEL":
                //Load lại nội dung từ Grid
                onSelectedChange("");

                // Disable tất cả Control
                EnabledInputs(false);
                break;
            case "@CommonMessage.TOOLBARITEM_SAVE":
                // Chuyển toàn bộ nội dung nhập liệu của các control trên form thành dữ liệu Text
                var data = $("form").serialize();

                // Kiểm tra trạng thái View, tùy từng trạng thái chuyển hướng SAVE khác nhau
                switch (formState) {
                    case "@CommonMessage.STATE_NEW":
                        // Lấy đường dẫn của Action Create trong Controller
                        var actionURL = '@Url.Action("Create")';
                        $.appAjax({
                            type: "POST",
                            url: actionURL,
                            data: data,
                            success: function (data) {
                                // Sau khi Save thành công, data sẽ là Id model vừa tạo
                                // Gọi hàm ChangeToolbarState để đổi trạng thái Toolbar
                                // Tham khải hàm ChangeToolbarState trong Coding Convention
                                ChangeToolbarState(false);

                                // Disable tất cả Control
                                EnabledInputs(false);

                                // Grid load lại nội dung
                                var grid = $("#Grid").data("kendoGrid");
                                grid.dataSource.fetch();

                                // Set lại Id của Model vừa tạo
                                $("#Id").val(data).change();
                            }
                        });
                        break;
                    case "@CommonMessage.STATE_EDIT":
                        // Lấy đường dẫn của Action Edit trong Controller
                        var actionURL = '@Url.Action("Edit")';
                        $.appAjax({
                            type: "POST",
                            url: actionURL,
                            data: data,
                            success: function (data) {
                                // Sau khi Save thành công, không quan tâm giá trị trả về, gọi hàm ChangeToolbarState để đổi trạng thái Toolbar
                                // Tham khải hàm ChangeToolbarState trong Coding Convention
                                ChangeToolbarState(false);

                                // Disable tất cả Control
                                EnabledInputs(false);

                                // Grid load lại nội dung
                                var grid = $("#Grid").data("kendoGrid");
                                grid.dataSource.fetch();
                            }
                        });
                        break;
                }
                break;
            case "@CommonMessage.TOOLBARITEM_DELETE":
                var grid = $("#Grid").data("kendoGrid");
                if (grid.select().length == 0) {
                    ShowAlert('Bạn chưa chọn dữ liệu nào.');
                }
                ShowConfirm('Bạn có muốn xóa dữ liệu này không?',
                    function () {
                        // Chọn có
                        // Lấy đường dẫn của Action Delete trong Controller
                        var actionURL = '@Url.Action("Delete")';
                        // Lấy Id của Item muốn xóa
                        var selectedItem = grid.dataItem(grid.select());
                        var data = "Id=" + selectedItem.Id;

                        $.appAjax({
                            type: "POST",
                            url: actionURL,
                            data: data,
                            success: function (data) {
                                // Sau khi Xóa thành công, không quan tâm giá trị trả về
                                // Xóa rỗng nội dung Id, để sau khi Grid load xong, sẽ tự động chọn Row đầu tiên
                                $("#Id").val("").change();

                                // Grid load lại nội dung
                                var grid = $("#Grid").data("kendoGrid");
                                grid.dataSource.fetch();
                            }
                        });
                    });
                break;
            case "@CommonMessage.TOOLBARITEM_ACTIVE":
                var grid = $("#Grid").data("kendoGrid");
                if (grid.select().length == 0) {
                    ShowAlert('Bạn chưa chọn dữ liệu nào.');
                }
                ShowConfirm('Bạn có muốn Áp dụng sử dụng dữ liệu này không?',
                    function () {
                        // Chọn có
                        // Lấy đường dẫn của Action Delete trong Controller
                        var actionURL = '@Url.Action("Active")';
                        // Lấy Id của Item muốn xóa
                        var selectedItem = grid.dataItem(grid.select());
                        var data = "Id=" + selectedItem.Id;

                        $.appAjax({
                            type: "POST",
                            url: actionURL,
                            data: data,
                            success: function (data) {
                                // Grid load lại nội dung
                                var grid = $("#Grid").data("kendoGrid");
                                grid.dataSource.fetch();
                            }
                        });
                    });
                break;
            case "@CommonMessage.TOOLBARITEM_DEACTIVE":
                var grid = $("#Grid").data("kendoGrid");
                if (grid.select().length == 0) {
                    ShowAlert('Bạn chưa chọn dữ liệu nào.');
                }
                ShowConfirm('Bạn có muốn Ngừng áp dụng sử dụng dữ liệu này không?',
                    function () {
                        // Chọn có
                        // Lấy đường dẫn của Action Delete trong Controller
                        var actionURL = '@Url.Action("Deactive")';
                        // Lấy Id của Item muốn xóa
                        var selectedItem = grid.dataItem(grid.select());
                        var data = "Id=" + selectedItem.Id;

                        $.appAjax({
                            type: "POST",
                            url: actionURL,
                            data: data,
                            success: function (data) {
                                // Grid load lại nội dung
                                var grid = $("#Grid").data("kendoGrid");
                                grid.dataSource.fetch();
                            }
                        });
                    });
                break;
        }
    }

    function onDataBound(arg) {
        // Sự kiện DataBound, kiểm tra xem số lượng Item. Nếu không có dữ liệu nào trong danh sách thì Disable các ToolbarItem khác ngoài Create
        var itemCount = this.dataSource.total();

        // Nếu không có row nào được select thì Disable các ToolbarItem trừ Create
        if (this.select().length == 0) {
            DisableAllToolbarItemExpectCreate(true);
        } else {
            DisableAllToolbarItemExpectCreate(itemCount == 0);
        }

        // Select lại item vừa chọn lấy từ Hidden field Id
        var grid = this;
        var id = $("#Id").val();
        if (id != null && id != '') {
            var dataItem = grid.dataSource.get(id);
            if (dataItem != null) {
                var row = grid.tbody.find("tr[data-uid='" + dataItem.uid + "']");
                grid.select(row);
            } else {
                // Nếu không tìm thấy Row với id thì chọn Row đầu tiên
                var row = grid.tbody.find("tr:first");
                grid.select(row);
            }
        } else {
            // Nếu Id rỗng (thao tác xóa, hoặc lần đầu tiên load View) thì chọn lại Row đầu tiên
            var row = grid.tbody.find("tr:first");
            grid.select(row);
        }
    }
})(jQuery);