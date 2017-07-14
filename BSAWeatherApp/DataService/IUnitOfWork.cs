using BSAWeatherApp.Models;

namespace BSAWeatherApp.DataService
{
    public interface IUnitOfWork
    {
        void Save();
        void Dispose();
        IRepository<CityModel> Cities { get; }
        IRepository<CityHistory> History { get; }
    }
}
