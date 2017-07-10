using BSAWeatherApp.Context;
using BSAWeatherApp.Services;
using System;
using System.Web.Mvc;

namespace BSAWeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        IUrlGenerator urlGenerator;
        IForecastProvider forecastProvider;
        BSAWeatherContext db = new BSAWeatherContext();
        public WeatherController(IForecastProvider fpParam, IUrlGenerator urlGParam)
        {
            forecastProvider = fpParam;
            urlGenerator = urlGParam;
        }

        // GET: Weather/Settings
        public ActionResult Home()
        {
            return View();
        }

        // POST : Weather/WeatherNow
        [HttpPost]
        public ActionResult WeatherNow(string weatherCity)
        {
            try
            {
                var url = urlGenerator.GenerateWeatherUrl(weatherCity);
                var model = forecastProvider.GetWeatherNowObject(url);
                return PartialView(model);
            }
            catch (AggregateException e)
            {
                return RedirectToAction("NotFound", "Error");
            }
        }

        // POST: Weather/Forecast
        public ActionResult Forecast(string defaultCity, string customCity, string daysCount)
        {
            try
            {
                var url = urlGenerator.GenerateForecastUrl(defaultCity, customCity, daysCount);
                var model = forecastProvider.GetWeatherForecastObject(url);
                return PartialView(model);
            }
            catch (AggregateException e)
            {
                return RedirectToAction("NotFound", "Error");
            }
        }

    }
}