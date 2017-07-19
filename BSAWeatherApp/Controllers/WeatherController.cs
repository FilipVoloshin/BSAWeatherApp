using BSAWeatherApp.Models;
using BSAWeatherApp.Services;
using BSAWeatherApp.Helpers;
using System;
using System.Collections;
using System.Web.Mvc;
using BSAWeatherApp.Models.DTO;
using AutoMapper;
using BSAWeatherApp.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BSAWeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        // GET: Weather/Home
        public ActionResult Home()
        {
            return View();
        }
    }
}