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
        public void GetForecastBySettings(int cityId, string customCity, string period)
        {

        }
    }
}