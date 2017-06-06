using System.Web.Optimization;

namespace proiectLicenta.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            //~/Bundles/App/vendor/css
            bundles.Add(
                new StyleBundle("~/Bundles/App/vendor/css")

                    .Include("~/Content/themes/base/all.css", new CssRewriteUrlTransform())
                    .Include("~/Content/bootstrap.min.css", new CssRewriteUrlTransform())
                    .Include("~/Content/toastr.min.css", new CssRewriteUrlTransform())
                    .Include("~/Scripts/sweetalert/sweet-alert.css", new CssRewriteUrlTransform())
                    .Include("~/Content/flags/famfamfam-flags.css", new CssRewriteUrlTransform())
                    .Include("~/Content/font-awesome.min.css", new CssRewriteUrlTransform())
                    .Include("~/Content/rzslider.css", new CssRewriteUrlTransform())
                    .Include("~/Content/isteven-multi-select.min.css", new CssRewriteUrlTransform())
                    .Include("~/Content/angular-chart.css", new CssRewriteUrlTransform())


                );

            //~/Bundles/App/vendor/js
            bundles.Add(
                new ScriptBundle("~/Bundles/App/vendor/js")
                    .Include(
                        "~/Abp/Framework/scripts/utils/ie10fix.js",
                        "~/Scripts/d3/d3-queue.v2.min.js",
                        "~/Scripts/json2.min.js",
                        "~/Scripts/d3/d3.min.js",
                        "~/Scripts/d3/d3-tip.js",
                        "~/Scripts/d3/topojson.min.js",
                        "~/Scripts/d3/us.json",
                        "~/Scripts/d3/us-states.json",
                        "~/Scripts/d3/world.json",
                        "~/Scripts/d3/us-cities.csv",
                        "~/Scripts/d3/Chart.js",



                        "~/Scripts/modernizr-{version}.js",

                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js",

                        "~/Scripts/bootstrap.min.js",

                        "~/Scripts/moment-with-locales.min.js",
                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/toastr.min.js",
                        "~/Scripts/sweetalert/sweet-alert.min.js",
                        "~/Scripts/others/spinjs/spin.js",
                        "~/Scripts/others/spinjs/jquery.spin.js",
                        "~/Scripts/lodash.core.min.js",
                        "~/Scripts/lodash.min.js",

                        "~/Scripts/angular.min.js",
                        "~/Scripts/angular-animate.min.js",
                        "~/Scripts/angular-sanitize.min.js",
                        "~/Scripts/angular-ui-router.min.js",
                        "~/Scripts/angular-ui/ui-bootstrap.min.js",
                        "~/Scripts/angular-ui/ui-bootstrap-tpls.min.js",
                        "~/Scripts/angular-ui/ui-utils.min.js",
                        "~/Scripts/angular-local-storage.js",
                        
                        "~/Scripts/rzslider.js",
                        
                        "~/Abp/Framework/scripts/abp.js",
                        "~/Abp/Framework/scripts/libs/abp.jquery.js",
                        "~/Abp/Framework/scripts/libs/abp.toastr.js",
                        "~/Abp/Framework/scripts/libs/abp.blockUI.js",
                        "~/Abp/Framework/scripts/libs/abp.spin.js",
                        "~/Abp/Framework/scripts/libs/abp.sweet-alert.js",
                        "~/Abp/Framework/scripts/libs/angularjs/abp.ng.js",
                        "~/Scripts/highstock/2.1.8/highstock.js",
                        "~/Scripts/highstock/2.1.8/exporting.js",
                        "~/Scripts/isteven-multi-select.min.js"
                    )
                    //.IncludeDirectory("~/Scripts/highstock", "*.js", true)
                );

            //APPLICATION RESOURCES

            //~/Bundles/App/Main/css
            bundles.Add(
                new StyleBundle("~/Bundles/App/Main/css")
                    .IncludeDirectory("~/App/Main", "*.css", true)
                    .IncludeDirectory("~/Content/AdminLTE", "*.css", true)
                );
            //.Include("~/Content/AdminLTE/AdminLTE.css", new CssRewriteUrlTransform())
            

            //~/Bundles/App/Main/js
            bundles.Add(
                new ScriptBundle("~/Bundles/App/Main/js")
                    .IncludeDirectory("~/Common/Scripts", "*.js", true)
                    .IncludeDirectory("~/App/Main", "*.js", true)
                    .IncludeDirectory("~/Scripts/AdminLTE", "*.js", true)
                    .Include("~/Scripts/d3/angular-chart.js")
                );
        }
    }
}