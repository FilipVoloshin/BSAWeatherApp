using BSAWeatherApp.Context;
using System;
using BSAWeatherApp.Models;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BSAWeatherApp.DataService
{
    public class UnitOfWork : IUnitOfWork
    {
        private BSAWeatherContext DbContext { get; set; }

        public IRepository<CityModel> Cities { get { return new Repository<CityModel>(DbContext); } }

        public IRepository<CityHistory> History { get { return new Repository<CityHistory>(DbContext); } }

        public UnitOfWork()
        {
            CreateDbContext();
        }

        private void CreateDbContext()
        {
            DbContext = new BSAWeatherContext();
        }

        public void Save()
        {
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    DbContext.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    ex.Entries.Single().Reload();
                }
            }
            while (saveFailed);
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}