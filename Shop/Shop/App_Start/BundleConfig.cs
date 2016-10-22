using System.Web;
using System.Web.Optimization;


namespace Shop
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {


            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/tooplate_style.css",
                "~/Content/ddsmoothmenu.css",
                "~/Content/jquery.dualSlider.0.2.css",
                "~/Content/slimbox2.css"));
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Scripts/ddsmoothmenu.js",
                "~/Scripts/jquery-1.3.2.min.js",
                "~/Scripts/jquery.dualSlider.0.3.js",
                "~/Scripts/jquery.dualSlider.0.3.min.js",
                "~/Scripts/jquery.easing.1.3.js",
                "~/Scripts/slimbox2.js",
                "~/Scripts/jquery.timers-1.2.js"));

        }
    }
}