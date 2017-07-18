using AutoMapper;
using BSAWeatherApp.Helpers;
using BSAWeatherApp.Models.DTO;
using BSAWeatherApp.Models.ViewModels;
using BSAWeatherApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BSAWeatherApp.API
{
    public class HistoryController : ApiController
    {
        IHistoryService historyService;
        IHistoryHelper historyHelper;
        public HistoryController(IHistoryService historyService, IHistoryHelper historyHelper)
        {
            this.historyService = historyService;
            this.historyHelper = historyHelper;
        }

        // GET api/history
        public IEnumerable<CityHistoryViewModel> Get()
        {
            var history = historyService.GetAllHistoryEntries();
            Mapper.Initialize(cfg => cfg.CreateMap<CityHistoryDTO, CityHistoryViewModel>());
            return (Mapper.Map<IEnumerable<CityHistoryDTO>, IEnumerable<CityHistoryViewModel>>(history));
        }

        //GET api/history/uman

        [Route("api/History/{cityName}")]
        public IHttpActionResult Get(string cityName)
        {
            var historyDto = historyService.GetAllHistoryEntries();
            Mapper.Initialize(cfg => cfg.CreateMap<CityHistoryDTO, CityHistoryViewModel>());
            var history = historyHelper.GetCityRequestCount(
                Mapper.Map<IEnumerable<CityHistoryDTO>, IEnumerable<CityHistoryViewModel>>(historyDto));
            var cityHistory = history.Where(city => city.City.ToLower() == cityName.ToLower())
                .FirstOrDefault();
            return Ok(cityHistory);
        }
    }
}