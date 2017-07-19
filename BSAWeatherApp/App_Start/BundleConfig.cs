using System.Web;
using System.Web.Optimization;

namespace BSAWeatherApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/own").Include(
                      "~/Scripts/weatherForecast.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/style.css"));

            bundles.Add(new StyleBundle("~/Content/fontawesome").Include(
                     "~/Content/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/Content/weathericons").Include(
                     "~/Content/weather-icons/weather-icons.css",
                     "~/Content/weather-icons/weather-icons-wind.css"));


        }
    }
}
