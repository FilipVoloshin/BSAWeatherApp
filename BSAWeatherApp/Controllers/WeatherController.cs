using BSAWeatherApp.Helpers;
using BSAWeatherApp.Services;
using System;
using System.Web.Mvc;

namespace BSAWeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private UrlGenerator _urlGenerator;
        private ForecastProvider _forecastProvide;

        public WeatherController()
        {
            _urlGenerator = new UrlGenerator();
            _forecastProvide = new ForecastProvider();
        }

        // GET: Weather/Settings
        public ActionResult Filter()
        {
            return View();
        }

        // POST : Weather/WeatherNow
        [HttpGet]
        public ActionResult WeatherNow(string weatherCity)
        {
            try
            {
                var url = _urlGenerator.GenerateWeatherUrl(weatherCity);
                var model = _forecastProvide.GetWeatherNowObject(url);
                return View(model);
            }
            catch (AggregateException e)
            {
                return RedirectToAction("NotFound", "Error");
            }
        }

        // GET: Weather/Forecast
        public ActionResult Forecast(string defaultCity, string customCity, string daysCount)
        {
            try
            {
                var url = _urlGenerator.GenerateForecastUrl(defaultCity, customCity, daysCount);
                var model = _forecastProvide.GetWeatherForecastObject(url);
                return View(model);
            }
            catch (AggregateException e)
            {
                return RedirectToAction("NotFound", "Error");
            }
        }

    }
}