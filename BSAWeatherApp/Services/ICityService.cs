using BSAWeatherApp.Models.DTO;
using System.Collections.Generic;

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
