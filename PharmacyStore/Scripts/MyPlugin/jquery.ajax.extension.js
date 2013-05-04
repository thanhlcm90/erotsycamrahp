// Các hàm jQuery mở rộng để xử dụng
// Copyright: Lê Cao Minh Thành

; (function ($, window, document, undefined) {

	var win = $(window),
		bod = $(document.body),
		main = $('#main-body'),
		firstload = false,
		viewtitle = '';

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
					console.log(xhr.status);
					if (xhr.status == 400) {
						ShowNotify(xhr.responseText, 'error');
					}
					else {
						ShowNotify('Trang yêu cầu không tồn tại.', 'error');
					}
					loading.closeModal();
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
	window.ChangeUrlHash = function (hash) {
		window.location.hash = '#' + hash;
		if (!bod.parent().hasClass('hashchange')) {
			win.hashchange();
		}
	}

	window.getURLParameters = function (paramName) {
		var sURL = window.document.URL.toString();
		if (sURL.indexOf("?") > 0) {
			var arrParams = sURL.split("?");
			var arrURLParams = arrParams[1].split("&");
			var i = 0;
			for (i = 0; i < arrURLParams.length; i++) {
				var sParam = arrURLParams[i].split("=");
				if (sParam[0] == paramName) {
					return unescape(sParam[1]);
				}
			}
		}
		return null;
	}

	// Xóa tham số khỏi địa chỉ URL Hash và trả về địa chỉ đã xóa
	window.removeURLHashParameters = function (paramName) {
		var sURL = window.document.URL.toString();
		if (sURL.indexOf("#") > 0) {
			var hash = sURL.split("#")[1];
			if (hash.indexOf("?") > 0) {
				var arrParams = hash.split("?");
				var arrURLParams = arrParams[1].split("&");
				var i = 0;
				for (i = 0; i < arrURLParams.length; i++) {
					var sParam = arrURLParams[i].split("=");
					if (sParam[0] == paramName) {
						if (hash.indexOf('&' + sParam[0]) != -1) {
							hash = hash.replace('&' + sParam[0] + '=' + sParam[1], '');
						} else {
							hash = hash.replace(sParam[0] + '=' + sParam[1], '');
						}
						return hash;
					}
				}
			}
			return hash;
		}
		return null;
	}

	// Thêm tham số vào địa chỉ URL Hash và trả về địa chỉ đã thêm
	window.addURLHashParameters = function (paramName, replace) {
		var sURL = window.document.URL.toString();
		if (sURL.indexOf("#") > 0) {
			var hash = sURL.split("#")[1];
			if (hash.indexOf("?") > 0) {
				var arrParams = hash.split("?");
				var arrURLParams = arrParams[1].split("&");
				var i = 0;
				for (i = 0; i < arrURLParams.length; i++) {
					var sParam = arrURLParams[i].split("=");
					if (sParam[0] == paramName) {
						hash = hash.replace(sParam[0] + '=' + sParam[1], sParam[0] + '=' + replace);
						return hash;
					}
				}
				hash += '&' + paramName + '=' + replace;
			} else {
				hash += '?' + paramName + '=' + replace;
			}
			return hash;
		}
		return null;
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
	    // Định dạng tất cả input Percent thàng Masked
		$(".mask-percent").inputmask("999%", { autoUnmask: true, placeholder: " " });
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

	$(document).ready(function () {
		FormatMaskedInput();

		//Đăng ký Hotkey
		RegisterHotkey();
	});
	function RegisterHotkey() {
		$.Shortcuts.add({
			type: 'up',
			mask: 'Shift+Alt+M',
			enableInInput: true,
			handler: function () {
				var b = $("a#Create.toolbaritem");
				if (b != null) {
					b.trigger("click");
				}
			}
		});
		$.Shortcuts.add({
			type: 'up',
			mask: 'Shift+Alt+S',
			enableInInput: true,
			handler: function () {
				var b = $("a#Edit.toolbaritem");
				if (b != null) {
					b.trigger("click");
				}
			}
		});
		$.Shortcuts.add({
			type: 'up',
			mask: 'Shift+Alt+L',
			enableInInput: true,
			handler: function () {
				var b = $("a#Save.toolbaritem");
				if (b != null) {
					b.trigger("click");
				}
			}
		});
		$.Shortcuts.add({
			type: 'up',
			mask: 'Shift+Alt+H',
			enableInInput: true,
			handler: function () {
				var b = $("a#Cancel.toolbaritem");
				if (b != null) {
					b.trigger("click");
				}
			}
		});
		$.Shortcuts.add({
			type: 'up',
			mask: 'Shift+Alt+X',
			enableInInput: true,
			handler: function () {
				var b = $("a#Delete.toolbaritem");
				if (b != null) {
					b.trigger("click");
				}
			}
		});
		$.Shortcuts.start();
	}

	window.DisableGrid = function (grid, enabled) {
		if (enabled) {
			var container = $("#" + grid);
			//Get container offset
			var position = container.offset();
			//Ger container height	
			var offsetHeight = container.height();
			//Get container width	
			var offsetWidth = container.width();
			//Appent to the body a new covered div with offset, width and height = offser, width and height of the container
			var newDiv = $("<div id = 'coverDiv' style='z-index:9999999'>").appendTo($("body"));
			newDiv.offset(position);
			newDiv.height(offsetHeight);
			// - 17px = width ot the scroller	
			newDiv.width(offsetWidth - 17);
		} else {
			$("#coverDiv").remove();
		}
	}

	function ChangeResolution() {
		if ($.template.mediaQuery.name == 'mobile-landscape') {
			$('#toolbar').trigger('detach.ScrollToFixed');
			$('#toolbar').scrollToFixed({ marginTop: 40 });
			$('.toolbaritem-text').addClass('hidden');
			$('.toolbaritem-text1').removeClass('hidden');
			$('.toolbaritem').attr('style', 'width:auto;')
		} else if ($.template.mediaQuery.name == 'mobile-portrait') {
			$('#toolbar').trigger('detach.ScrollToFixed');
			$('#toolbar').scrollToFixed();
			$('.toolbaritem-text').addClass('hidden')
			$('.toolbaritem-text1').addClass('hidden');
			$('.toolbaritem').attr('style', 'width:0px;')
		} else {
			$('#toolbar').trigger('detach.ScrollToFixed');
			$('#toolbar').scrollToFixed({ marginTop: 40 });
			$('.toolbaritem-text').removeClass('hidden')
			$('.toolbaritem-text1').addClass('hidden');
			$('.toolbaritem').attr('style', 'width:auto;')
		}
	}

	$(document).on('init-queries', function () {
		ChangeResolution();
	});
	$(document).on('change-query', function () {
		ChangeResolution();
	});

	$(document).on('click', '.disabled', function (event) {
		event.preventDefault();
		event.stopImmediatePropagation();
		return;
	});

	// If the browser support the Notification API, ask user for permission (with a little delay)
	if (notify.hasNotificationAPI() && !notify.isNotificationPermissionSet()) {
		setTimeout(function () {
			notify.showNotificationPermission('Your browser supports desktop notification, click here to enable them.', function () {
				// Confirmation message
				if (notify.hasNotificationPermission()) {
					notify('Notifications API enabled!', 'You can now see notifications even when the application is in background', {
						icon: 'img/demo/icon.png',
						system: true
					});
				}
				else {
					notify('Notifications API disabled!', 'Desktop notifications will not be used.', {
						icon: 'img/demo/icon.png'
					});
				}
			});

		}, 2000);
	}

	//Thay đổi giao diện các control chuẩn của html thành của kendo
	function TransformKendo() {
		$("input").each(function () {
			var type = $(this).attr("type");
			if (type == 'text' || type == 'password' || type == 'email') {
				$(this).addClass('k-textbox');
			} else if (type == 'submit' || type == 'reset') {
				$(this).addClass('k-button');
			}
		});
	}

	function ResetValidations() {
		$('.field-validation-error').empty();
		$('input').each(function () {
			$(this).removeClass('input-validation-error');
		});
	}

	// Ajax navigation, xử lý click hash change
	$(document).on('click', 'a', function (event) {
		var link = $(this),
			href = link.attr('href'),
			docmenu;
		// Some elements from the doc shouldn't be processed
		if (link.closest('.navigable, .collapsible, #shortcuts, .mlddm').length == 0) {
			event.preventDefault();
			return;
		}

		// If local link
		if (href && !href.match(/^(https?:|#|\.\/|javascript:)/)) {
			event.preventDefault();
			ChangeUrlHash(href);

			// If in menu, add visual indicator
			docmenu = link.closest('#shortcuts');
			if (docmenu.length > 0) {
				docmenu.find('.current').removeClass('current');
				link.parent().addClass('current');
			}
		}
	});

	window.ToolbarCommand = function (command) { }

	// Listen to hash changes
	win.hashchange(function (event) {
		var hash = $.trim(window.location.hash || '');
		if (hash.length > 1) {
			var actionURL = hash.substring(1);
			var controller = actionURL.split('?')[0];
			var IdParam = getURLParameters('Id');
			if (main.attr('url-loaded') != controller) {
				$.appAjax({
					type: "POST",
					url: actionURL,
					data: "",
					success: function (data) {
						var scripts = $(data).filter('script');
						scripts.each(function () {
							var script = $(this);
							var scriptNode = document.createElement('script');
							scriptNode.appendChild(
								document.createTextNode(script.html())
							);
							document.body.appendChild(scriptNode);
						});
						// Gán Attribute url đã Load và gán nội dung Html vào div main
						main.attr("url-loaded", controller).html(data);

						// Reset lại Validation
						$("form").removeData("validator");
						$("form").removeData("unobtrusiveValidation");
						$.validator.unobtrusive.parse("form");

						// Load trạng thái Form theo hash
						var command = getURLParameters("state");
						if (command != null) {
							ChangeToolbarState(true);
							ToolbarCommand(command);
						} else {
							ChangeToolbarState(false);
							ResetValidations();
						}

						// Đánh dầu lần đầu tiên Load
						firstload = true;
					},
					error: function (xhr) {
					}
				});
			} else {
				firstload = false;
				var command = getURLParameters("state");
				if (command != null) {
					ChangeToolbarState(true);
					ToolbarCommand(command);
				} else {
					ChangeToolbarState(false);
					ResetValidations();
					ToolbarCommand('Cancel');
				}
			}
		}
		else {
			window.location.reload();
		}
	});

	// Init
	if (window.location.hash && window.location.hash.length > 1) {
		win.hashchange();
	}


	window.onDataBound = function (arg) {
		try {
			// Sự kiện DataBound, kiểm tra xem số lượng Item. Nếu không có dữ liệu nào trong danh sách thì Disable các ToolbarItem khác ngoài Create
			var itemCount = this.dataSource.total();

			var grid = this;

			// Nếu không có row nào được select thì Disable các ToolbarItem trừ Create
			if (this.select().length == 0) {
				DisableAllToolbarItemExpectCreate(true);
			} else {
				DisableAllToolbarItemExpectCreate(itemCount == 0);
			}

			// Select lại item vừa chọn lấy từ Hidden field Id
			// Kiểm tra trạng thái form, nếu trạng thái New/Edit thì bỏ qua bước select này
			var command = getURLParameters("state");
			var IdParam = getURLParameters("Id");
			if (command == null || command == 'Edit') {
				//var id = $("#Id").val();
				if (IdParam != null && IdParam != '') {
					var IdParams = IdParam.split('-');
					var id = IdParams[0];
					var dataItem = grid.dataSource.get(id);
					if (dataItem != null) {
						var row = grid.tbody.find("tr[data-uid='" + dataItem.uid + "']");
						grid.select(row);
					} else {
						// Nếu không tìm thấy Row với id thì chọn đổi Page, chọn lại
						var page = IdParams[1];
						var pageSize = IdParams[2];
						if (firstload) {
							grid.dataSource.pageSize(pageSize);
							grid.dataSource.page(page);
						} else {
							var row = grid.tbody.find("tr:first");
							grid.select(row);
						}
						firstload = false;
					}
				} else {
					// Nếu Id rỗng (thao tác xóa, hoặc lần đầu tiên load View) thì chọn lại Row đầu tiên
					var row = grid.tbody.find("tr:first");
					grid.select(row);
				}
			}
		} catch (ex) { }
	}

	window.onSelectedChange = function (arg) {
		try {
			var grid = $("#Grid").data("kendoGrid");
			if (grid == null) return;
			if (grid.select() == null) return;
			// Lấy row được select và set cho MVVM
			var selectedItem = grid.dataItem(grid.select());
			if (selectedItem != null) {
				var id = '';
				id = selectedItem.Id;
				var gridPage = grid.dataSource.page();
				var gridPageSize = grid.dataSource.pageSize();
				id += '-' + gridPage + '-' + gridPageSize;
				ChangeUrlHash(addURLHashParameters("Id", id));
				OnGridSelectedChange(selectedItem);

				// Format các Mask Input
				FormatMaskedInput();
			}
			// Enable toàn  bộ ToolbarItem
			DisableAllToolbarItemExpectCreate(false);
		} catch (ex) { }
	}

	window.ViewTitle = function (str) {
		$(".ViewTitle").html(str);
		document.title = str;
	}

})(this.jQuery, window, document);