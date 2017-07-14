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

namespace BSAWeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        IUrlGenerator urlGenerator;
        IForecastProvider forecastProvider;
        ICityService cityService;
        IHistoryService historyService;
        HistoryHelper historyHelper;

        public WeatherController(IForecastProvider forecastProvider, IUrlGenerator urlGenerator,
            ICityService cityService, IHistoryService historyService)
        {
            this.forecastProvider = forecastProvider;
            this.urlGenerator = urlGenerator;
            this.cityService = cityService;
            this.historyService = historyService;
            historyHelper = new HistoryHelper();
        }

        // GET: Weather/Settings
        public ActionResult Home()
        {
            var citiesDtos = cityService.GetAllCities();
            Mapper.Initialize(cfg => cfg.CreateMap<CityDTO, CityViewModel>());
            var cities = Mapper.Map<IEnumerable<CityDTO>, IEnumerable<CityViewModel>>(citiesDtos);
            return View(cities);
        }

        // POST : Weather/WeatherNow
        [HttpPost]
        public ActionResult WeatherNow(string weatherCity)
        {
            try
            {
                var url = urlGenerator.GenerateWeatherUrl(weatherCity);
                var model = forecastProvider.GetWeatherNowObject(url);
                historyService.AddHistory(new CityHistoryDTO
                {
                    CityName = weatherCity,
                    DateTimeOfSearch = DateTime.Now
                });
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
                historyService.AddHistory(new CityHistoryDTO
                {
                    CityName = model.City.Name,
                    DateTimeOfSearch = DateTime.Now
                });
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
            var citiesDtos = cityService.GetAllCities();
            Mapper.Initialize(cfg => cfg.CreateMap<CityDTO, CityViewModel>());
            var cities = Mapper.Map<IEnumerable<CityDTO>, IEnumerable<CityViewModel>>(citiesDtos);
            return View(cities);
        }

        //POST: Weather/AddCity
        [HttpPost]
        public ActionResult AddCity(CityViewModel city)
        {
            if (city != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<CityViewModel, CityDTO>());
                var cityDto = Mapper.Map<CityViewModel, CityDTO>(city);
                cityService.CreateCity(cityDto);
                return Json(new { Success = true, City = city });
            }
            return Json(new { Success = false });
        }

        //POST: Weather/DeleteCity
        [HttpPost]
        public ActionResult DeleteCity(int id)
        {
            if (id != 0)
            {
                cityService.DeleteCity(id);
                return Json(new { Message = "Deleted!" });
            }
            return Json(new { Message = "Error!" });

        }

        //POST: Weather/UpdateCity
        [HttpPost]
        public ActionResult UpdateCity(CityViewModel city)
        {
            if (city != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<CityViewModel, CityDTO>());
                var cityDto = Mapper.Map<CityViewModel, CityDTO>(city);
                cityService.UpdateCity(cityDto);
                return Json(new { Message = "Updated!" });
            }
            return Json(new { Message = "Error!" });

        }

        //GET: Weather/RequestHistory
        public ActionResult RequestHistory()
        {
            var historyDto = historyService.GetAllHistoryEntries();
            Mapper.Initialize(cfg => cfg.CreateMap<CityHistoryDTO, CityHistoryViewModel>());
            var history = historyHelper.GetCityRequestCount(
                Mapper.Map<IEnumerable<CityHistoryDTO>,IEnumerable<CityHistoryViewModel>>(historyDto));
            return View(history);
        }
    }
}