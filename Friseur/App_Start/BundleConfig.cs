﻿using System.Web;
using System.Web.Optimization;

namespace Friseur
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js"));

                        

            // JQuery toastr.   
            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
            "~/Scripts/toastr.js"));

            // JQuery validator.   
            bundles.Add(new ScriptBundle("~/bundles/custom-validator").Include(
                                  "~/Scripts/script-custom-validator.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-lumen.css",
                      "~/Content/site.css"));
        }
    }
}
