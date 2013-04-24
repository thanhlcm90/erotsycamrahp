using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

public static class CommonFunction
{
    public static IHtmlString BuildToolbar(params ToolbarItem[] items)
    {
        try
        {
            StringBuilder toolbar = new StringBuilder();
            toolbar.AppendLine("<div id='toolbar' class='white-gradient wrapped full-width with-small-padding margin-bottom'>");
            toolbar.AppendLine("<a command='" + CommonMessage.TOOLBARITEM_SAVE + "' href='javascript:void(0)' class='toolbaritem button hidden'><span class='button-icon blue-gradient'><span class='" + CommonMessage.TOOLBARITEM_SAVE_ICON + "'></span></span><div class='toolbaritem-text'>Lưu thay đổi</div><div class='toolbaritem-text1 hidden'>Lưu</div></a>");
            toolbar.AppendLine("<a command='" + CommonMessage.TOOLBARITEM_CANCEL + "' href='javascript:void(0)' class='toolbaritem button hidden'><span class='button-icon red-gradient'><span class='" + CommonMessage.TOOLBARITEM_CANCEL_ICON + "'></span></span><div class='toolbaritem-text'>Hủy bỏ</div><div class='toolbaritem-text1 hidden'>Hủy</div></a>");
            foreach (ToolbarItem item in items)
            {
                string strName = "";
                string strText = "";
                string strText1 = "";
                string icon = "";
                string color = "blue-gradient";
                string hasEdited = "false";
                ToolbarAuthorize Authorize = ToolbarAuthorize.None;
                switch (item)
                {
                    case ToolbarItem.Create:
                        strName = CommonMessage.TOOLBARITEM_CREATE;
                        Authorize = ToolbarAuthorize.Create;
                        strText = "Thêm mới";
                        strText1 = "Thêm";
                        hasEdited = "true";
                        icon = CommonMessage.TOOLBARITEM_CREATE_ICON;
                        break;
                    case ToolbarItem.Edit:
                        strName = CommonMessage.TOOLBARITEM_EDIT;
                        Authorize = ToolbarAuthorize.Modify;
                        strText = "Sửa dữ liệu";
                        strText1 = "Sửa";
                        hasEdited = "true";
                        icon = CommonMessage.TOOLBARITEM_EDIT_ICON;
                        break;
                    case ToolbarItem.Delete:
                        strName = CommonMessage.TOOLBARITEM_DELETE;
                        Authorize = ToolbarAuthorize.Delete;
                        strText = "Xóa dữ liệu";
                        strText1 = "Xóa";
                        color = "red-gradient";
                        icon = CommonMessage.TOOLBARITEM_DELETE_ICON;
                        break;
                    case ToolbarItem.Save:
                        strName = CommonMessage.TOOLBARITEM_SAVE;
                        strText = "Lưu thay đổi";
                        strText1 = "Lưu";
                        icon = CommonMessage.TOOLBARITEM_SAVE_ICON;
                        break;
                    case ToolbarItem.Cancel:
                        strName = CommonMessage.TOOLBARITEM_CANCEL;
                        strText = "Hủy bỏ";
                        strText1 = "Hủy";
                        color = "red-gradient";
                        icon = CommonMessage.TOOLBARITEM_CANCEL_ICON;
                        break;
                    case ToolbarItem.Print:
                        strName = CommonMessage.TOOLBARITEM_PRINT;
                        strText = "In";
                        strText1 = "In";
                        Authorize = ToolbarAuthorize.Print;
                        icon = CommonMessage.TOOLBARITEM_PRINT_ICON;
                        break;
                    case ToolbarItem.Import:
                        strName = CommonMessage.TOOLBARITEM_IMPORT;
                        strText = "Import dữ liệu";
                        strText1 = "Import";
                        Authorize = ToolbarAuthorize.Import;
                        icon = CommonMessage.TOOLBARITEM_IMPORT_ICON;
                        break;
                    case ToolbarItem.Export:
                        strName = CommonMessage.TOOLBARITEM_EXPORT;
                        strText = "Export dữ liệu";
                        strText1 = "Export";
                        Authorize = ToolbarAuthorize.Export;
                        icon = CommonMessage.TOOLBARITEM_EXPORT_ICON;
                        break;
                    case ToolbarItem.Active:
                        strName = CommonMessage.TOOLBARITEM_ACTIVE;
                        strText = "Áp dụng";
                        strText1 = "Áp dụng";
                        Authorize = ToolbarAuthorize.Active;
                        icon = CommonMessage.TOOLBARITEM_ACTIVE_ICON;
                        break;
                    case ToolbarItem.Deactive:
                        strName = CommonMessage.TOOLBARITEM_DEACTIVE;
                        strText = "Ngừng áp dụng";
                        strText1 = "Ngừng AD";
                        Authorize = ToolbarAuthorize.Active;
                        icon = CommonMessage.TOOLBARITEM_DEACTIVE_ICON;
                        break;
                }
                toolbar.AppendLine("<a command='" + strName + "' itemedited='" + hasEdited + "' href='javascript:void(0)' class='toolbaritem button'><span class='button-icon " + color + "'><span class='" + icon + "'></span></span><div class='toolbaritem-text'>" + strText + "</div><div class='toolbaritem-text1 hidden'>" + strText1  + "</div></a>");
            }
            toolbar.AppendLine("</div>");
            return MvcHtmlString.Create(toolbar.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public enum ToolbarAuthorize
    {
        Create,
        Modify,
        Delete,
        Print,
        Import,
        Export,
        Active,
        None
    }

}

public enum ToolbarItem
{
    Create,
    Edit,
    Delete,
    Save,
    Cancel,
    Print,
    Import,
    Export,
    Active,
    Deactive
}