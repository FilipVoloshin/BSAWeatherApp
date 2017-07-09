using BSAWeatherApp.Services;
using System;
using System.Web.Mvc;

namespace BSAWeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        // GET: Weather/Settings
        public ActionResult Filter()
        {
            return View();
        }

        // GET: Weather/Forecast
        public ActionResult Forecast(string defaultCity, string customCity, string period)
        {
            try
            {
                var weatherForecast = new ForecastProvider();
                var weatherForecastVm = weatherForecast.GetWeatherForecast(defaultCity, customCity, period);
                return View(weatherForecastVm);
            }
            catch (AggregateException e)
            {
                return RedirectToAction("NotFound","Error");
            }
        }

    }
}