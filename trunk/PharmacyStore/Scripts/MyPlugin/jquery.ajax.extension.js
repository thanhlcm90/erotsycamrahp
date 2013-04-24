// Các hàm jQuery mở rộng để xử dụng
// Copyright: Lê Cao Minh Thành

(function ($) {

    $.appAjax = function (options) {
        // Hàm gọi Ajax đã được xử lý Lỗi và Loading
        // Ví dụ mẫu:
        //    $.appAjax(
        //      "Person/Add",
        //      "POST",
        //      function() { return $(this).serializeArray(); },
        //      function (data) {
        //      });
        if (options && typeof (options) == 'object') {
            new myAjax(options.url, options.type, options.data, options.success, options.error);
        }
    }

    var myAjax = function (url, type, data, success, error) {
        /// <summary>Đoạn jQuery mở rộng này sẽ gọi hàm Ajax và kiểm soát lỗi, loading.</summary>
        /// <param name="url" type="String">Địa chỉ mà Ajax gọi.</param>
        /// <param name="type" type="String">HTTP method type (GET, POST, DELETE, PUT, HEAD)</param>
        /// <param name="data" type="Function">Khai báo tham số hàm hoăc dữ liệu, mục đích truyền data khi gọi Ajax.</param>
        /// <param name="success" type="Function">Khai báo tham số là 1 hàm. Sẽ gọi khi thành công.</param>

        var execSuccess = $.isFunction(success) ? success : $.noop;
        var execError = $.isFunction(error) ? error : $.noop;
        var getData = $.isFunction(data) ? data : function () { return data; };
        var loading = openLoadingModal();
        try {
            $.ajax({
                url: url,
                type: type,
                data: getData(),
                error: function (xhr, status, err) {
                    if (xhr.status == 400) {
                        ShowNotify(xhr.responseText, 'error');
                    }
                    else {
                        ShowNotify('Không kết nối được với Server', 'error');
                    }
                    execError(xhr);
                },
                success: function (data, status, xhr) {
                    if (data && typeof (data) == 'object') {
                        var result = data.result;
                        if (result == 'success') {
                            ShowNotify('Thao tác thực hiện thành công', 'success');
                            execSuccess(data.data);
                            FormatMaskedInput();
                        } else if (result == 'fail') {
                            ShowNotify('Thao tác thực hiện KHÔNG thành công', 'error');
                            execError(xhr);
                        }
                        execSuccess(data.data);
                    } else {
                        execSuccess(data);
                    }
                },
                complete: function () {
                    loading.closeModal();
                }
            });
        } catch (ex) {
            loading.closeModal();
        }
        function openLoadingModal() {
            return $.modal({
                contentAlign: 'center',
                resizable: false,
                width: 240,
                content: '<div style="line-height: 25px; padding: 0 0 10px"><span id="modal-status">Kết nối Server...</span><br><span id="modal-progress">0%</span></div>',
                buttons: {},
                scrolling: false,
                actions: {},
                onOpen: function () {
                    // Progress bar
                    $('#modal-progress').progress(100, {
                        size: 200,
                        style: 'large',
                        barClasses: ['anthracite-gradient', 'glossy'],
                        stripes: true,
                        darkStripes: false,
                        showValue: false
                    })
                }
            });
        };
    }

    window.ShowNotify = function (message, type) {
        /// <summary>Đoạn jQuery mở rộng này sẽ hiển thị lỗi.</summary>
        /// <param name="message" type="String">Địa chỉ mà Ajax gọi.</param>
        /// <param name="type" type="String">Kiểu Message ('error', 'success', 'alert')</param>
        var classes;
        var textOneSimilar = 'Một thông báo giống';
        var textSeveralSimilars = '%d thông báo giống';
        switch (type.toUpperCase()) {
            case 'ERROR':
                classes = 'red-gradient glossy align-center';
                break;
            case 'SUCCESS':
                classes = 'blue-gradient glossy align-center';
                break;
            case 'ALERT':
                classes = 'align-center';
                break;
        }
        notify(message, {
            hPos: 'center',
            closeDelay: 5000,
            showCloseOnHover: false,
            classes: classes,
            textOneSimilar: textOneSimilar,
            textSeveralSimilars: textSeveralSimilars
        });
    }

    window.ChangeToolbarState = function (edit) {
        /// <summary>Đoạn jQuery mở rộng này sẽ thay đổi trạng thái của Toolbar ở chế độ bình thường hay chế độ chỉnh sửa.</summary>
        /// <param name="edit" type="String/bool">Giá trị bool hoặc string: là chế độ của Toolbar (true: chế độ edit, false: chế độ bình thường)</param>
        switch (edit) {
            case "true": case "yes": case "1": case true:
                $(".toolbaritem").each(function () {
                    var item = $(this);
                    var att = item.attr("command");
                    if (att == "Save" || att == "Cancel") {
                        item.removeClass("hidden");
                    } else {
                        item.addClass("hidden");
                    }
                });
                break;
            case "false": case "no": case "0": case null: case false:
                $(".toolbaritem").each(function () {
                    var item = $(this);
                    var att = item.attr("command");
                    if (att == "Save" || att == "Cancel") {
                        item.addClass("hidden");
                    } else {
                        item.removeClass("hidden");
                    }
                });
                break;
        }
    }

    window.EnabledInputs = function (enabled) {
        /// <summary>Đoạn jQuery mở rộng này sẽ Enable/Disable tất cả các Input trên View.</summary>
        /// <param name="edit" type="bool">Giá trị bool: true - Enable, false - Disable</param>
        $(".input").each(function () {
            if (enabled) {
                $(this).removeClass("disabled");
                $(this).removeAttr("disabled");
            } else {
                $(this).addClass("disabled");
                $(this).attr('disabled', 'disabled');
            }
        })

        $(".input-unstyled").each(function () {
            if (enabled) {
                $(this).removeAttr("disabled");
            } else {
                $(this).attr('disabled', 'disabled');
            }
        })
    }

    window.FormatMaskedInput = function () {
        /// <summary>Đoạn jQuery mở rộng này sẽ định dạng tất cả các Input có class mask thành dạng Mask Input.</summary>
        // Định dang tất cả input Date thành Masked
        $(".mask-date").inputmask("dd/mm/yyyy", { placeholder: "dd/mm/yyyy" });
        // Định dạng tất cả input Phone thàng Masked
        $(".mask-phone").inputmask("(84) 999999999999", { autoUnmask: true, placeholder: " " });
        // Định dạng tất cả input Number thàng Masked
        $(".mask-number").inputmask("9", { repeat: 255, greedy: false });
        // Định dạng tất cả input Money thàng Masked
        $(".mask-money").inputmask("integer", { autoGroup: true, groupSeparator: ",", groupSize: 3, autoUnmask: true });
        $(":input").each(function () {
            var max = $(this).attr('data-val-length-max');
            if (max != null && max != '') {
                $(this).attr('maxlength', max);
                $(this).inputmask();
            }
        })
    }

    window.ClearAllInput = function (form) {
        /// <summary>Đoạn jQuery mở rộng này sẽ xóa trắng tất cả Input trên Form.</summary>
        $("#" + form).find(":input").each(function () {
            var name = $(this).attr("name");
            if (name != '__RequestVerificationToken') {
                // .val().change() : để trigger với MVVM
                $(this).val("").change();
            }
        });
    }

    window.FocusFirstInput = function () {
        /// <summary>Đoạn jQuery mở rộng này sẽ Focus vào Input đầu tiên của Form.</summary>
        $("form").find("input:visible").first().focus();
    }

    window.DisableAllToolbarItemExpectCreate = function (disabled) {
        /// <summary>Đoạn jQuery mở rộng này sẽ Disable toàn bộ các ToolbarItem ngoài Create, Save, Cancel.</summary>
        /// <param name="disabled" type="bool">True - Disable , False - Enable</param>
        $(".toolbaritem").each(function () {
            var item = $(this);
            var att = item.attr("command");
            if (att != "Create" && att != "Save" && att != "Cancel") {
                if (!disabled) {
                    item.removeClass("disabled");
                    item.removeAttr("disabled");
                } else {
                    item.addClass("disabled");
                    item.attr('disabled', 'disabled');
                }
            }
        });
    }

    window.ShowAlert = function (msg) {
        /// <summary>Đoạn jQuery mở rộng này sẽ hiển thị hộp thoại thông báo.</summary>
        /// <param name="msg" type="string">Nội dung thông báo</param>
        $.modal.alert(msg, {
            buttons: {
                'Đóng': {
                    classes: 'blue-gradient glossy big full-width',
                    click: function (modal) { modal.closeModal(); }
                }
            }
        });
    }

    window.ShowConfirm = function (msg, ok) {
        /// <summary>Đoạn jQuery mở rộng này sẽ hiển thị hộp thoại Xác nhận (Có/Không)</summary>
        /// <param name="msg" type="string">Nội dung thông báo</param>
        /// <param name="ok" type="function">Function trả về khi nhấn CÓ</param>
        $.modal.confirm(msg, ok, function () { }, {
            textCancel: 'Không',
            textConfirm: 'Có'
        });
    }
})(jQuery);