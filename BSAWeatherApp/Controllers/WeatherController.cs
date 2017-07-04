using System.Web.Mvc;

namespace BSAWeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        // GET: Weather
        public ActionResult Forecast()
        {
            return View();
        }
    }
}