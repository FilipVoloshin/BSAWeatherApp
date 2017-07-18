using BSAWeatherApp.Helpers;
using System.Net.Http.Headers;
using System.Web.Http;

namespace BSAWeatherApp.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            //Convert to JSON format
            configuration.Formatters.Add(new BrowserJsonFormatter());

            configuration.MapHttpAttributeRoutes();

            configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}