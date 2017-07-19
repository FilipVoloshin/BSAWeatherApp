using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSAWeatherApp.Controllers
{
    public class CitiesManagementController : Controller
    {
        // GET: CitiesManagement
        public ActionResult Index()
        {
            return View();
        }
    }
}