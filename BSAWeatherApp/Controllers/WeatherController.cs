using BSAWeatherApp.Services;
using System.Web.Mvc;

namespace BSAWeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        // GET: Weather/Settings
        public ActionResult Filter()
        {
            ViewBag.Error = false;
            return View();
        }

        // GET: Weather/Forecast
        public ActionResult Forecast(string defaultCity, string customCity, string period)
        {
            var weatherForecast = new ForecastProvider();
            var weatherForecastVm = weatherForecast.GetWeatherForecast(defaultCity, customCity, period);
            return View(weatherForecastVm);
        }

    }
}