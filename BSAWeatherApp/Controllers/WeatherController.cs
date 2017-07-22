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
        ICityService cityService;

        public WeatherController(IUrlGenerator urlGenerator, IHistoryService historyService,
           IForecastProvider forecastProvider, ICityService cityService)
        {
            this.urlGenerator = urlGenerator;
            this.historyService = historyService;
            this.forecastProvider = forecastProvider;
            this.cityService = cityService;
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
                    DateTimeOfSearch = DateTime.Now,
                    IsSuccess = true
                });
                return View(model);
            }
            catch(Exception e)
            {
                historyService.AddHistory(new CityHistoryDTO
                {
                    CityName = weatherCity,
                    DateTimeOfSearch = DateTime.Now,
                    IsSuccess = false
                });
                return RedirectToAction("NotFound", "Error",e.Message);
            }
        }

        //GET: Weather/Forecast
        public ActionResult Forecast()
        {
            var citiesDtos = cityService.GetAllCities();
            Mapper.Initialize(cfg => cfg.CreateMap<CityDTO, CityViewModel>());
            var cities = Mapper.Map<IEnumerable<CityDTO>,IEnumerable<CityViewModel>>(citiesDtos);
            return View(cities);
        }

        //POST: Weather/Forecast
        [HttpPost]
        public ActionResult Forecast(string defaultCity, string customCity, string daysCount)
        {
            try
            {
                var url = urlGenerator.GenerateForecastUrl(defaultCity,customCity,daysCount);
                var model = forecastProvider.GetWeatherForecastObject(url);
                historyService.AddHistory(new CityHistoryDTO
                {
                    CityName = model.City.Name,
                    DateTimeOfSearch = DateTime.Now,
                    IsSuccess = true
                });
                return PartialView("_Forecast", model);
            }
            catch(Exception e)
            {
                var cityName = String.IsNullOrEmpty(customCity) ? defaultCity : customCity;
                historyService.AddHistory(new CityHistoryDTO
                {
                    CityName = cityName,
                    DateTimeOfSearch = DateTime.Now,
                    IsSuccess = false
                });
                return RedirectToAction("NotFound", "Error", e.Message);
            }
        }
    }
}