using AutoMapper;
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
    public class CitiesController : ApiController
    {
        ICityService cityService;

        public CitiesController(ICityService cityService)
        {
            this.cityService = cityService;
        }


        // GET api/cities
        public IEnumerable<CityViewModel> Get()
        {
            var citiesDTO = cityService.GetAllCities();
            Mapper.Initialize(cfg => cfg.CreateMap<CityDTO, CityViewModel>());
            return Mapper.Map<IEnumerable<CityDTO>, IEnumerable<CityViewModel>>(citiesDTO);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}