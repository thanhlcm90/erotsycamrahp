using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;

public static class CommonFunction
{
    public static IHtmlString BuildToolbar(params ToolbarItem[] items)
    {
        try
        {
            StringBuilder toolbar = new StringBuilder();
            toolbar.AppendLine("<div id='toolbar' class='white-gradient wrapped full-width with-small-padding margin-bottom'>");
            toolbar.AppendLine("<a command='" + CommonMessage.TOOLBARITEM_SAVE + "' href='javascript:void(0)' class='toolbaritem button hidden with-tooltip tooltip-bottom' title='Lưu dữ liệu (Phím tắt: SHIFT + ALT + L)'><span class='button-icon blue-gradient'><span class='" + CommonMessage.TOOLBARITEM_SAVE_ICON + "'></span></span><div class='toolbaritem-text'><u>L</u>ưu thay đổi</div><div class='toolbaritem-text1 hidden'><u>L</u>ưu</div></a>");
            toolbar.AppendLine("<a command='" + CommonMessage.TOOLBARITEM_CANCEL + "' href='javascript:void(0)' class='toolbaritem button hidden with-tooltip tooltip-bottom' title='Hủy bỏ thao tác (Phím tắt: SHIFT + ALT + H)'><span class='button-icon red-gradient'><span class='" + CommonMessage.TOOLBARITEM_CANCEL_ICON + "'></span></span><div class='toolbaritem-text'><u>H</u>ủy bỏ</div><div class='toolbaritem-text1 hidden'><u>H</u>ủy</div></a>");
            foreach (ToolbarItem item in items)
            {
                string strName = "";
                string strText = "";
                string strText1 = "";
                string icon = "";
                string color = "blue-gradient";
                string hasEdited = "false";
                string tooltip = "";
                ToolbarAuthorize Authorize = ToolbarAuthorize.None;
                switch (item)
                {
                    case ToolbarItem.Create:
                        strName = CommonMessage.TOOLBARITEM_CREATE;
                        Authorize = ToolbarAuthorize.Create;
                        strText = "Thêm <u>m</u>ới";
                        strText1 = "Thê<u>m</u>";
                        tooltip = "Thêm mới 1 dữ liệu (Phím tắt: SHIFT + ALT + M)";
                        hasEdited = "true";
                        icon = CommonMessage.TOOLBARITEM_CREATE_ICON;
                        break;
                    case ToolbarItem.Edit:
                        strName = CommonMessage.TOOLBARITEM_EDIT;
                        Authorize = ToolbarAuthorize.Modify;
                        strText = "<u>S</u>ửa dữ liệu";
                        strText1 = "<u>S</u>ửa";
                        tooltip = "Sửa dữ liệu (Phím tắt: SHIFT + ALT + S)";
                        hasEdited = "true";
                        icon = CommonMessage.TOOLBARITEM_EDIT_ICON;
                        break;
                    case ToolbarItem.Delete:
                        strName = CommonMessage.TOOLBARITEM_DELETE;
                        Authorize = ToolbarAuthorize.Delete;
                        strText = "<u>X</u>óa dữ liệu";
                        strText1 = "<u>X</u>óa";
                        tooltip = "Xóa dữ liệu (Phím tắt: SHIFT + ALT + X)";
                        color = "red-gradient";
                        icon = CommonMessage.TOOLBARITEM_DELETE_ICON;
                        break;
                    case ToolbarItem.Save:
                        strName = CommonMessage.TOOLBARITEM_SAVE;
                        strText = "<u>L</u>ưu thay đổi";
                        strText1 = "<u>L</u>ưu";
                        tooltip = "Lưu dữ liệu (Phím tắt: SHIFT + ALT + L)";
                        icon = CommonMessage.TOOLBARITEM_SAVE_ICON;
                        break;
                    case ToolbarItem.Cancel:
                        strName = CommonMessage.TOOLBARITEM_CANCEL;
                        strText = "<u>H</u>ủy bỏ";
                        strText1 = "<u>H</u>ủy";
                        tooltip = "Hủy bỏ thao tác (Phím tắt: SHIFT + ALT + H)";
                        color = "red-gradient";
                        icon = CommonMessage.TOOLBARITEM_CANCEL_ICON;
                        break;
                    case ToolbarItem.Print:
                        strName = CommonMessage.TOOLBARITEM_PRINT;
                        strText = "In";
                        strText1 = "In";
                        tooltip = "In";
                        Authorize = ToolbarAuthorize.Print;
                        icon = CommonMessage.TOOLBARITEM_PRINT_ICON;
                        break;
                    case ToolbarItem.Import:
                        strName = CommonMessage.TOOLBARITEM_IMPORT;
                        strText = "Import dữ liệu";
                        strText1 = "Import";
                        tooltip = "Import dữ liệu";
                        Authorize = ToolbarAuthorize.Import;
                        icon = CommonMessage.TOOLBARITEM_IMPORT_ICON;
                        break;
                    case ToolbarItem.Export:
                        strName = CommonMessage.TOOLBARITEM_EXPORT;
                        strText = "Export dữ liệu";
                        strText1 = "Export";
                        tooltip = "Export dữ liệu";
                        Authorize = ToolbarAuthorize.Export;
                        icon = CommonMessage.TOOLBARITEM_EXPORT_ICON;
                        break;
                    case ToolbarItem.Active:
                        strName = CommonMessage.TOOLBARITEM_ACTIVE;
                        strText = "Áp dụng";
                        strText1 = "Áp dụng";
                        tooltip = "Áp dụng dữ liệu sử dụng trong hệ thống";
                        Authorize = ToolbarAuthorize.Active;
                        icon = CommonMessage.TOOLBARITEM_ACTIVE_ICON;
                        break;
                    case ToolbarItem.Deactive:
                        strName = CommonMessage.TOOLBARITEM_DEACTIVE;
                        strText = "Ngừng áp dụng";
                        strText1 = "Ngừng AD";
                        tooltip = "Ngừng áp dụng dữ liệu sử dụng trong hệ thống";
                        Authorize = ToolbarAuthorize.Active;
                        icon = CommonMessage.TOOLBARITEM_DEACTIVE_ICON;
                        break;
                }
                toolbar.AppendLine("<a command='" + strName + "' itemedited='" + hasEdited + "' href='javascript:void(0)' class='toolbaritem button with-tooltip tooltip-bottom' title='" + tooltip + "'><span class='button-icon " + color + "'><span class='" + icon + "'></span></span><div class='toolbaritem-text'>" + strText + "</div><div class='toolbaritem-text1 hidden'>" + strText1 + "</div></a>");
            }
            toolbar.AppendLine("</div>");
            return MvcHtmlString.Create(toolbar.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public static IHtmlString BuildMenu()
    {
        try
        {
            string appDataPath = HttpContext.Current.Server.MapPath("~/App_Data");
            string file = Path.Combine(appDataPath, "Menu.xml");
            if (!System.IO.File.Exists(file))
            {
                return MvcHtmlString.Empty;
            }
            string stringReturn = "";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(file);
            XmlNode xElement = xmlDoc.DocumentElement.FirstChild;

            for (int i = 0; i <= xElement.ChildNodes.Count - 1; i++)
            {
                XmlNode xChildElement = xElement.ChildNodes[i];
                stringReturn += "<li>";
                stringReturn += "<a href='#'>" + xChildElement.Attributes["Text"].Value + "</a>";
                if (xChildElement.HasChildNodes)
                {
                    stringReturn += getChildElement(xChildElement.FirstChild);
                }
                stringReturn += "</li>";
            }
            return MvcHtmlString.Create(stringReturn);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private static string getChildElement(XmlNode xElement)
    {
        string stringReturn = "<ul>";
        for (int i = 0; i <= xElement.ChildNodes.Count - 1; i++)
        {
            XmlNode xChildElement = xElement.ChildNodes[i];
            stringReturn += "<li>";
            stringReturn += "<a href='/" + xChildElement.Attributes["Controller"].Value + "'>" + xChildElement.Attributes["Text"].Value + "</a>";
            if (xChildElement.HasChildNodes)
            {
                stringReturn += getChildElement(xChildElement.FirstChild);
            }
            stringReturn += "</li>";
        }
        stringReturn += "</ul>";
        return stringReturn;
    }

    public static IHtmlString BuildUserMenu()
    {
        try
        {
            string appDataPath = HttpContext.Current.Server.MapPath("~/App_Data");
            string file = Path.Combine(appDataPath, "Menu.xml");
            if (!System.IO.File.Exists(file))
            {
                return MvcHtmlString.Empty;
            }
            string stringReturn = "";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(file);
            XmlNode xElement = xmlDoc.DocumentElement.FirstChild;

            for (int i = 0; i <= xElement.ChildNodes.Count - 1; i++)
            {
                XmlNode xChildElement = xElement.ChildNodes[i];
                stringReturn += "<li class='with-right-arrow'>";
                stringReturn += "<span>" + xChildElement.Attributes["Text"].Value + "</span>";
                if (xChildElement.HasChildNodes)
                {
                    stringReturn += getChildElementUserMenu(xChildElement.FirstChild);
                }
                stringReturn += "</li>";
            }
            return MvcHtmlString.Create(stringReturn);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    private static string getChildElementUserMenu(XmlNode xElement)
    {
        string stringReturn = "<ul class='big-menu'>";
        for (int i = 0; i <= xElement.ChildNodes.Count - 1; i++)
        {
            XmlNode xChildElement = xElement.ChildNodes[i];
            if (xChildElement.HasChildNodes)
            {
                stringReturn += "<li class='with-right-arrow'>";
            }
            else
            {
                stringReturn += "<li>";
            }
            if (xChildElement.Attributes["Controller"] == null || xChildElement.Attributes["Controller"].Value == "")
            {
                stringReturn += "<span>" + xChildElement.Attributes["Text"].Value + "</span>";
            }
            else
            {
                stringReturn += "<a href='/" + xChildElement.Attributes["Controller"].Value + "'>" + xChildElement.Attributes["Text"].Value + "</a>";
            }
            if (xChildElement.HasChildNodes)
            {
                stringReturn += getChildElement(xChildElement.FirstChild);
            }
            stringReturn += "</li>";
        }
        stringReturn += "</ul>";
        return stringReturn;
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