using BSAWeatherApp.DataService;
using System;
using System.Collections.Generic;

namespace BSAWeatherApp.Tests.Fake
{
    class FakeUnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public void SetRepository<T>(IRepository<T> repository) where T: class, IEntity
        {
            _repositories[typeof(T)] = repository;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public IRepository<T> Repository<T>() where T: class,IEntity
        {
            object repository;
            return _repositories.TryGetValue(typeof(T), out repository)
                ? (IRepository<T>)repository
                : new FakeRepository<T>();
        }
    }
}
