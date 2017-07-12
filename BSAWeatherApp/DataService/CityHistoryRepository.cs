using BSAWeatherApp.Context;
using BSAWeatherApp.Models;
using System;
using System.Collections.Generic;

namespace BSAWeatherApp.DataService
{
    public class CityHistoryRepository : IRepository<CityHistory>
    {
        private BSAWeatherContext db;
        public CityHistoryRepository()
        {
            this.db = new BSAWeatherContext();
        }

        public void Create(CityHistory searchHistoryItem)
        {
            db.History.Add(searchHistoryItem);
        }

        public IEnumerable<CityHistory> GetAll()
        {
            return db.History;
        }

        public CityHistory GetItem(int id)
        {
            return db.History.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }
        #region Not implemented yet
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public void Update(CityHistory item)
        {
            throw new NotImplementedException();
        }
        #endregion

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