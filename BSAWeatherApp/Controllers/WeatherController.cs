using BSAWeatherApp.Helpers;
using BSAWeatherApp.Services;
using System;
using System.Web.Mvc;

namespace BSAWeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private UrlGenerator _urlGenerator;

        public WeatherController()
        {
            _urlGenerator = new UrlGenerator();
        }

        // GET: Weather/Settings
        public ActionResult Filter()
        {
            return View();
        }
        public ActionResult WeatherNow(string weatherCity)
        {
            var url = _urlGenerator.GenerateWeatherUrl(weatherCity);
            return View();
        }
        // GET: Weather/Forecast
        public ActionResult Forecast(string defaultCity, string customCity, string daysCount)
        {
            try
            {
                var url = _urlGenerator.GenerateForecastUrl(defaultCity, customCity, daysCount);
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