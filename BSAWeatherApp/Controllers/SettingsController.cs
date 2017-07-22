using AutoMapper;
using BSAWeatherApp.Helpers;
using BSAWeatherApp.Models.DTO;
using BSAWeatherApp.Models.ViewModels;
using BSAWeatherApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSAWeatherApp.Controllers
{
    public class SettingsController : Controller
    {
        ICityService cityService;
        IHistoryService historyService;
        IHistoryHelper historyHelper;

        public SettingsController(ICityService cityService, IHistoryService historyService,
            IHistoryHelper historyHelper)
        {
            this.cityService = cityService;
            this.historyHelper = historyHelper;
            this.historyService = historyService;
        }

        // GET: Settings/CityManage
        public ActionResult CityManage()
        {
            var citiesDtos = cityService.GetAllCities();
            Mapper.Initialize(cfg => cfg.CreateMap<CityDTO, CityViewModel>());
            var cities = Mapper.Map<IEnumerable<CityDTO>, IEnumerable<CityViewModel>>(citiesDtos);

            var historyDto = historyService.GetAllHistoryEntries();
            Mapper.Initialize(cfg => cfg.CreateMap<CityHistoryDTO, CityHistoryViewModel>());
            var history = Mapper.Map<IEnumerable<CityHistoryDTO>, IEnumerable<CityHistoryViewModel>>(historyDto);
            var citySearchStatistic = historyHelper.GetCityRequestCount(history);

            var model = new SettingsViewModel
            {
                Cities = cities,
                CityHistory = history,
                SearchStatistic = citySearchStatistic
            };
            return View(model);
        }

        //POST: Settings/AddCity
        [HttpPost]
        public ActionResult AddCity(CityViewModel city)
        {
            try
            {
                if (city.Name == null)
                    throw new ArgumentNullException("Error with creating city!");
                city.DateOfCreate = DateTime.Now;
                Mapper.Initialize(cfg => cfg.CreateMap<CityViewModel, CityDTO>());
                var cityDto = Mapper.Map<CityViewModel, CityDTO>(city);
                cityService.CreateCity(cityDto);

                var citiesDtos = cityService.GetAllCities();
                Mapper.Initialize(cfg => cfg.CreateMap<CityDTO, CityViewModel>());
                var cities = Mapper.Map<IEnumerable<CityDTO>, IEnumerable<CityViewModel>>(citiesDtos);
                return PartialView("_CreateCity", cities);
            }
            catch (ArgumentNullException e)
            {
                return RedirectToAction("NotFound", "Error", e.Message);
            }
        }

        //POST: Settings/DeleteCity
        [HttpPost]
        public void DeleteCity(int id)
        {
            cityService.DeleteCity(id);
        }

        //POST: Settings/ClearHistory
        [HttpPost]
        public void ClearHistory()
        {
            historyService.ClearHistory();
        }
    }
}