using System.Web.Mvc;

namespace BSAWeatherApp.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error/NotFound
        public ActionResult NotFound()
        {
            return PartialView();
        }
    }
}