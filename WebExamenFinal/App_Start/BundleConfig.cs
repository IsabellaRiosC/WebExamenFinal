using System.Web;
using System.Web.Optimization;

namespace WebExamenFinal
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                   "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/unobtrusive-ajax").Include(
                      "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/modal").Include(
                 "~/Scripts/Shared/modal.js"));

            bundles.Add(new ScriptBundle("~/bundles/paginator").Include(
                 "~/Scripts/jquery.bootpag.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/producto").Include(
                   "~/Areas/Maestro/Scripts/producto.js"));

            bundles.Add(new ScriptBundle("~/bundles/cliente").Include(
                   "~/Areas/Maestro/Scripts/cliente.js"));

            bundles.Add(new ScriptBundle("~/bundles/proveedor").Include(
                   "~/Areas/Maestro/Scripts/proveedor.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css")
                      .Include("~/Css/site.css"));
        }
    }
}
