using BSAWeatherApp.Models;
using BSAWeatherApp.Services;
using System;
using System.Web.Mvc;

namespace BSAWeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private WeatherForecast _weatherForecast;

        public WeatherController()
        {
            _weatherForecast = new WeatherForecast();
        }
        // GET: Weather/Settings
        public ActionResult Filter()
        {
            return View();
        }

        //POST: Weather/GetForecastBySettings
        [HttpPost]
        public ActionResult GetForecastBySettings(string city, string customCity, string period)
        {
            var jsonWeatherResult = _weatherForecast.GetWeatherForecast(city,customCity,period);
            return RedirectToAction("Forecast");
        }

        // GET: Weather/Forecast
        public ActionResult Forecast()
        {
            return View();
        }

    }
}