using System.Web;
using System.Web.Optimization;

namespace PharmacyStore
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jQuery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/myplugin").Include(
                        "~/Scripts/MyPlugin/jquery-scrolltofixed.js",
                        "~/Scripts/MyPlugin/jquery.ajax.extension.js"));

            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
                        "~/Scripts/jquery.inputmask/jquery.inputmask.js",
                        "~/Scripts/jquery.inputmask/jquery.inputmask.extensions.js",
                        "~/Scripts/jquery.inputmask/jquery.inputmask.date.extensions.js",
                        "~/Scripts/jquery.inputmask/jquery.inputmask.numeric.extensions.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ba-hashchange").Include(
                        "~/Scripts/developer/libs/jquery.ba-hashchange.min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            //            "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jQuery/jquery.unobtrusive*",
                        "~/Scripts/jQuery/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/developr/modernizr").Include(
                      "~/Scripts/developr/libs/modernizr.custom.js"));

            bundles.Add(new StyleBundle("~/Content/developr/print").Include(
                        "~/Content/developr/print.css"));
            bundles.Add(new StyleBundle("~/Content/developr/480").Include(
                        "~/Content/developr/480.css"));
            bundles.Add(new StyleBundle("~/Content/developr/768").Include(
                        "~/Content/developr/768.css"));
            bundles.Add(new StyleBundle("~/Content/developr/992").Include(
                        "~/Content/developr/992.css"));
            bundles.Add(new StyleBundle("~/Content/developr/1200").Include(
                        "~/Content/developr/1200.css"));
            bundles.Add(new StyleBundle("~/Content/developr/resolutionRetina").Include(
                        "~/Content/developr/2x.css"));
            bundles.Add(new StyleBundle("~/Content/developr/mainstyle").Include(
                        "~/Content/developr/reset.css",
                        "~/Content/developr/style.css",
                        "~/Content/developr/colors.css",
                        "~/Content/developr/styles/form.css",
                        "~/Content/developr/styles/modal.css",
                        "~/Content/developr/styles/progress-slider.css",
                        "~/Content/developr/styles/switches.css",
                        "~/Content/developr/styles/table.css",
                        "~/Content/css/validator.css"));
            bundles.Add(new ScriptBundle("~/developr/mainscript").Include(
                      "~/Scripts/developr/setup.js",
                      "~/Scripts/developr/developr.input.js",
                      "~/Scripts/developr/developr.notify.js",
                      "~/Scripts/developr/developr.message.js",
                      "~/Scripts/developr/developr.tooltip.js",
                      "~/Scripts/developr/developr.navigable.js",
                      "~/Scripts/developr/developr.scroll.js",
                      "~/Scripts/developr/developr.details.js",
                      "~/Scripts/developr/developr.table.js",
                      "~/Scripts/developr/developr.modal.js",
                      "~/Scripts/developr/developr.progress-slider.js",
                      "~/Scripts/developr/libs/jquery.details.min.js",
                      "~/Scripts/developr/libs/tinycon.min.js"));
            bundles.Add(new StyleBundle("~/Content/developr/loginstyle").Include(
                        "~/Content/developr/reset.css",
                        "~/Content/developr/style.css",
                        "~/Content/developr/colors.css",
                        "~/Content/developr/styles/form.css",
                        "~/Content/developr/styles/switches.css"));
            bundles.Add(new StyleBundle("~/Content/developr/loginstylemedia").Include(
                        "~/Content/developr/login.css"));
            bundles.Add(new ScriptBundle("~/developr/loginscript").Include(
                      "~/Scripts/developr/setup.js",
                      "~/Scripts/developr/developr.input.js",
                      "~/Scripts/developr/developr.notify.js",
                      "~/Scripts/developr/developr.message.js",
                      "~/Scripts/developr/developr.tooltip.js"));
            bundles.Add(new StyleBundle("~/Content/menustyle").Include(
                        "~/Content/css/jMenu.css"));
            bundles.Add(new ScriptBundle("~/Scripts/menuscript").Include(
                        "~/Scripts/MyPlugin/jMenu.js"));

            bundles.Add(new StyleBundle("~/Content/kendo").Include(
                        "~/Content/kendo/2012.3.1114/kendo.common.min.css",
                        "~/Content/kendo/2012.3.1114/kendo.blueopal.min.css"));
            bundles.Add(new ScriptBundle("~/Scripts/kendo").Include(
                        "~/Scripts/kendo/2012.3.1114/kendo.all.min.js",
                        "~/Scripts/kendo/2012.3.1114/kendo.aspnetmvc.min.js"));
            //BundleTable.EnableOptimizations = true;
        }
    }
}