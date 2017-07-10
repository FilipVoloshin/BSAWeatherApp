﻿using BSAWeatherApp.DataService;
using BSAWeatherApp.Models;
using BSAWeatherApp.Services;
using System;
using System.Collections;
using System.Web.Mvc;

namespace BSAWeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        IUrlGenerator urlGenerator;
        IForecastProvider forecastProvider;
        IRepository<CityModel> citiesDb;

        public WeatherController(IForecastProvider forecastProvider, IUrlGenerator urlGenerator,
            IRepository<CityModel> citiesDb)
        {
            this.forecastProvider = forecastProvider;
            this.urlGenerator = urlGenerator;
            this.citiesDb = citiesDb;
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
        [HttpPost]
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

        //GET: Weather/Settings
        public ActionResult Settings()
        {
            var data = citiesDb.GetAll();
            return View(data);
        }

        public ActionResult AddCity(CityModel city)
        {
            if (city != null)
            {
                citiesDb.Create(city);
                citiesDb.Save();
                return Json(new { Success = true, City = city });
            }
            return Json(new { Success = false });
        }
    }
}