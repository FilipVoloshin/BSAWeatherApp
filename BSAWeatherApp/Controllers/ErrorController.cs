using System.Web.Mvc;

namespace BSAWeatherApp.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NotFound()
        {
            return View();
        }
    }
}