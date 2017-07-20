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
        IUrlGenerator urlGenerator;
        IHistoryService historyService;
        IForecastProvider forecastProvider;

        public WeatherController(IUrlGenerator urlGenerator, IHistoryService historyService,
           IForecastProvider forecastProvider)
        {
            this.urlGenerator = urlGenerator;
            this.historyService = historyService;
            this.forecastProvider = forecastProvider;
        }

        // GET: Weather/Home
        public ActionResult Home()
        {
            return View();
        }

        //POST: Weather/Current
        public ActionResult Current(string weatherCity)
        {
            try
            {
                var url = urlGenerator.GenerateWeatherUrl(weatherCity);
                var model = forecastProvider.GetWeatherNowObject(url);
                if (model == null || String.IsNullOrEmpty(weatherCity))
                    throw new ArgumentNullException("Empty field. Fill the weather city input.");
                historyService.AddHistory(new CityHistoryDTO
                {
                    CityName = model.Name,
                    DateTimeOfSearch = DateTime.Now
                });
                return View(model);
            }
            catch(Exception e)
            {
                return RedirectToAction("NotFound", "Error",e.Message);
            }
        }
    }
}