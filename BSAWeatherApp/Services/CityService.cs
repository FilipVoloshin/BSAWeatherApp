using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BSAWeatherApp.Models.DTO;
using BSAWeatherApp.DataService;
using BSAWeatherApp.Models;
using AutoMapper;

namespace BSAWeatherApp.Services
{
    public class CityService : ICityService
    {
        IUnitOfWork Database { get; set; }
        public CityService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void CreateCity(CityDTO city)
        {
            if (city == null)
                throw new ValidationException("City was't foud!","");
            Mapper.Initialize(cfg => cfg.CreateMap<CityDTO, CityModel>());
            Database.Cities.Create(Mapper.Map<CityDTO, CityModel>(city));
            Database.Save();
        }

        public void DeleteCity(int id)
        {
            Database.Cities.Delete(id);
            Database.Save();
        }

        public IEnumerable<CityDTO> GetAllCities()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CityModel, CityDTO>());
            return Mapper.Map<IEnumerable<CityModel>, List<CityDTO>>(Database.Cities.GetAll());
        }

        public CityDTO GetCity(object id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CityModel, CityDTO>());
            return Mapper.Map<CityModel, CityDTO>(Database.Cities.GetItem(id));
        }

        public void UpdateCity(CityDTO city)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CityDTO, CityModel>());
            Database.Cities.Update(Mapper.Map<CityDTO, CityModel>(city));
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}