using BSAWeatherApp.Models;
using BSAWeatherApp.Services;
using System;
using System.Web.Mvc;

namespace BSAWeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private Services.WeatherForecast _weatherForecast;
        public WeatherController()
        {
            _weatherForecast = new Services.WeatherForecast();
        }
        // GET: Weather/Forecast
        public ActionResult Forecast()
        {
            return View();
        }

        //POST: Weather/GetForecastBySettings
        [HttpPost]
        public void GetForecastBySettings(string city, string customCity, string period)
        {
            _weatherForecast.GetWeatherForecast(city,period);
        }
    }
}