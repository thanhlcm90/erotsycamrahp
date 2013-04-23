using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

public static class Bundles
{
    public static IHtmlString Render(string path, object htmlAttributes)
    {
        return Render(path, new RouteValueDictionary(htmlAttributes));
    }
    public static IHtmlString RenderFormat(string path, string format)
    {
        return Render(path, format);
    }

    public static IHtmlString Render(string path, IDictionary<string, object> htmlAttributes)
    {
        var attributes = BuildHtmlStringFrom(htmlAttributes);

        string tagWithAttribute = string.Format(
            "<link rel=\"stylesheet\" href=\"{0}\" type=\"text/css\"{1} />",
            Styles.Url(path), attributes);
        return MvcHtmlString.Create(tagWithAttribute);
    }
    public static IHtmlString Render(string path, string format)
    {
        string tagWithAttribute = string.Format(
            format, Styles.Url(path));
        Console.WriteLine(Styles.Url(path));

        return MvcHtmlString.Create(tagWithAttribute);
    }

    private static string BuildHtmlStringFrom(IEnumerable<KeyValuePair<string, object>> htmlAttributes)
    {
        var builder = new StringBuilder();

        foreach (var attribute in htmlAttributes)
        {
            builder.AppendFormat(" {0}=\"{1}\"", attribute.Key, attribute.Value);
        }

        return builder.ToString();
    }
}

public class BundlesFormats
{
    public const string PRINT = @"<link href=""{0}"" rel=""stylesheet"" media=""print"" />";
    public const string SCREEN = @"<link href=""{0}"" rel=""stylesheet"" media=""screen"" />";
    public const string RES480 = @"<link href=""{0}"" rel=""stylesheet"" media=""only all and (min-width: 480px)"" />";
    public const string RES768 = @"<link href=""{0}"" rel=""stylesheet"" media=""only all and (min-width: 768px)"" />";
    public const string RES992 = @"<link href=""{0}"" rel=""stylesheet"" media=""only all and (min-width: 992px)"" />";
    public const string RES1200 = @"<link href=""{0}"" rel=""stylesheet"" media=""only all and (min-width: 1200px)"" />";
    public const string RETINA = @"<link href=""{0}"" rel=""stylesheet"" media=""only all and (-webkit-min-device-pixel-ratio: 1.5), only screen and (-o-min-device-pixel-ratio: 3/2), only screen and (min-device-pixel-ratio: 1.5)"" />";
}