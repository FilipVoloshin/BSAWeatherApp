using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BSAWeatherApp.Models.DTO;
using BSAWeatherApp.DataService;
using BSAWeatherApp.Models;
using AutoMapper;
using System.Linq.Expressions;
using BSAWeatherApp.Models.ViewModels;

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
            Database.Repository<CityModel>().Create(Mapper.Map<CityDTO, CityModel>(city));
            Database.Save();
        }

        public void DeleteCity(int id)
        {
            Database.Repository<CityModel>().Delete(id);
            Database.Save();
        }

        public IEnumerable<CityDTO> GetAllCities()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CityModel, CityDTO>());
            return Mapper.Map<IEnumerable<CityModel>, List<CityDTO>>(Database.Repository<CityModel>().GetAll());
        }

        public CityDTO GetCity(int id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CityModel, CityDTO>());
            return Mapper.Map<CityModel, CityDTO>(Database.Repository<CityModel>().GetItem(id));
        }

        public void UpdateCity(CityDTO city)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CityDTO, CityModel>());
            Database.Repository<CityModel>().Update(Mapper.Map<CityDTO, CityModel>(city));
            Database.Save();
        }

        public int GetIdOfLastAddedCity()
        {
            return GetAllCities().ToList().OrderByDescending(c => c.Id).FirstOrDefault().Id;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}