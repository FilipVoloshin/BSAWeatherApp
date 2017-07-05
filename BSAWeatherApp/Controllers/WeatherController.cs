using BSAWeatherApp.Models;
using System;
using System.Web.Mvc;

namespace BSAWeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        // GET: Weather/Forecast
        public ActionResult Forecast()
        {
            return View();
        }

        //POST: Weather/GetForecastBySettings
        [HttpPost]
        public void GetForecastBySettings(string city, string customCity, string period)
        {

        }
    }
}