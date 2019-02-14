using System.Web;
using System.Web.Optimization;

namespace SampleHomepage
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                         "~/Scripts/animsition.min.js",
                          "~/Scripts/popper.js",
                           "~/Scripts/select2.min.js",
                            "~/Scripts/slick.min.js",
                             "~/Scripts/countdowntime.js",
                             "~/Scripts/lightbox.min.js",
                             "~/Scripts/sweetalert.minx.js",
                             "~/Scripts/slick-custom.js",
                             "~/Scripts/main.js",
                               "~/Scripts/modernizr-*"

                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/font-awesome.min.css",
                        "~/Content/themify-icons.css",
                        "~/Content/icon-font.min.css",
                        "~/Content/style.css",
                        "~/Content/animate.css",
                        "~/Content/hamburgers.min.css",
                        "~/Content/animsition.min.css",
                        "~/Content/select2.min.css",
                        "~/Content/daterangepicker.css",
                        "~/Content/slick.css",
                        "~/Content/lightbox.min.css",
                        "~/Content/util.css",
                        "~/Content/main.css"
                      ));
        }
    }
}
