using BSAWeatherApp.Models;

namespace BSAWeatherApp.DataService
{
    public interface IUnitOfWork
    {
        void Save();
        void Dispose();
        IRepository<T> Repository<T>() where T : class, IEntity;
    }
}
