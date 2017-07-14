using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BSAWeatherApp.DataService
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T GetItem(object id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
