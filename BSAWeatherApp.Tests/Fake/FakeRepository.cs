using BSAWeatherApp.DataService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BSAWeatherApp.Tests.Fake
{
    public class FakeRepository<T> : IRepository<T>
        where T : class,IEntity
    {
        public readonly List<T> Data;

        public void Create(T item)
        {
            Data.Add(item);
        }

        public void Delete(int id)
        {
            var value = Data.FirstOrDefault(t=>t.Id == id);
            if (value != null)
                Data.Remove(value);
        }

        public IEnumerable<T> GetAll()
        {
            return Data;
        }

        public T GetItem(int id)
        {
            return Data.FirstOrDefault(t => t.Id == id);
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
