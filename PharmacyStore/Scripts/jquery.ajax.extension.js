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
            new myAjax(options.url, options.type, options.data, options.success);
        }
    }

    var myAjax = function (url, type, data, success) {
        /// <summary>Đoạn jQuery mở rộng này sẽ gọi hàm Ajax và kiểm soát lỗi, loading.</summary>
        /// <param name="url" type="String">Địa chỉ mà Ajax gọi.</param>
        /// <param name="type" type="String">HTTP method type (GET, POST, DELETE, PUT, HEAD)</param>
        /// <param name="data" type="Function">Khai báo tham số hàm hoăc dữ liệu, mục đích truyền data khi gọi Ajax.</param>
        /// <param name="success" type="Function">Khai báo tham số là 1 hàm. Sẽ gọi khi thành công.</param>

        var execSuccess = $.isFunction(success) ? success : $.noop;
        var getData = $.isFunction(data) ? data : function () { return data; };
        var loading = openLoadingModal();
        $.ajax({
            url: url,
            type: type,
            data: getData(),
            error: function (xhr, status, err) {
                if (xhr.status == 400) {
                    showMessage(xhr.responseText, 'error');
                }
                else {
                    showMessage('Không kết nối được với Server', 'error');
                }
            },
            success: function (data, status, xhr) {
                if (data == 'success') {
                    $.showMessage('Thao tác thực hiện thành công', 'success');
                } else if (data == 'fail') {
                    $.showMessage('Thao tác thực hiện KHÔNG thành công', 'error');
                }
                execSuccess(data);
            },
            complete: function () {
                loading.closeModal();
            }
        });

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

    $.showMessage = function (message, type) {
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
})(jQuery);