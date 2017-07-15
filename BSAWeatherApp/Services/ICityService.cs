using BSAWeatherApp.Models.DTO;
using BSAWeatherApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BSAWeatherApp.Services
{
    public interface ICityService
    {
        void CreateCity(CityDTO city);
        void DeleteCity(int id);
        void UpdateCity(CityDTO city);
        CityDTO GetCity(object id);
        IEnumerable<CityDTO> GetAllCities();
        void Dispose();
    }
}
