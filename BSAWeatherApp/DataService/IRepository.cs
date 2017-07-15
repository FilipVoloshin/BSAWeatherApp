using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BSAWeatherApp.DataService
{
    public interface IRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        T GetItem(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
