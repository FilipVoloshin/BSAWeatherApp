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


        // GET: api/cities
        public IEnumerable<CityViewModel> Get()
        {
            var citiesDTO = cityService.GetAllCities();
            Mapper.Initialize(cfg => cfg.CreateMap<CityDTO, CityViewModel>());
            return Mapper.Map<IEnumerable<CityDTO>, IEnumerable<CityViewModel>>(citiesDTO);
        }

        //GET: api/cities/72
        public IHttpActionResult Get(int id)
        {
            var city = cityService.GetCity(id);
            if (city == null)
                return NotFound();
            Mapper.Initialize(cfg => cfg.CreateMap<CityDTO, CityViewModel>());
            return Ok(Mapper.Map<CityDTO, CityViewModel>(city));

        }

        // POST: api/cities
        public IHttpActionResult Post([FromBody]CityViewModel city)
        {
            if (city != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<CityViewModel, CityDTO>());
                cityService.CreateCity(Mapper.Map<CityViewModel, CityDTO>(city));
                return Ok();
            }
            else
                return NotFound();
        }

        // PUT: api/cities/72
        public IHttpActionResult Put([FromBody]CityViewModel city)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CityViewModel, CityDTO>());
            cityService.UpdateCity(Mapper.Map<CityViewModel, CityDTO>(city));
            return Ok();
        }

        // DELETE: api/cities/72
        public IHttpActionResult Delete(int id)
        {
            var cityDto = cityService.GetCity(id);
            if (cityDto != null)
            {
                cityService.DeleteCity(id);
                return Ok();
            }
            else
                return NotFound();
        }
    }
}