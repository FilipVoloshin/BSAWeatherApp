using BSAWeatherApp.Context;
using BSAWeatherApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BSAWeatherApp.DataService
{
    public class CitiesRepository : IRepository<CityModel>
    {
        private BSAWeatherContext db;
        public CitiesRepository()
        {
            this.db = new BSAWeatherContext();
        }

        public void Create(CityModel city)
        {
            db.Cities.Add(city);
        }

        public void Delete(int id)
        {
            var city = db.Cities.Find(id);
            if (city != null)
                db.Cities.Remove(city);
        }

        public IEnumerable<CityModel> GetAll()
        {
            return db.Cities;
        }

        public CityModel GetItem(int id)
        {
            return db.Cities.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(CityModel city)
        {
            db.Entry(city).State = EntityState.Modified;
        }

        #region IDisposable Support
        private bool disposed = false; 

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}