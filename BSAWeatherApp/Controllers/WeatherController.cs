using BSAWeatherApp.Helpers;
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
        public ActionResult Forecast(string defaultCity, string customCity, string daysCount)
        {
            try
            {
                var generator = new UrlGenerator(defaultCity,customCity,daysCount);
                var url = generator.GenerateUrlByFilterSettings();
                var forecastService = new ForecastProvider();
                var model = forecastService.GetWeatherApiObject(url);
                return View(model);
            }
            catch (AggregateException e)
            {
                return RedirectToAction("NotFound","Error");
            }
        }

    }
}