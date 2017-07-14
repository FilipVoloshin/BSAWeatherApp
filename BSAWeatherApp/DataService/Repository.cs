using BSAWeatherApp.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BSAWeatherApp.DataService
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        protected DbContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }
        public Repository(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ValidationException("dbContext error", "");
            else
            {
                DbContext = dbContext;
                DbSet = DbContext.Set<T>();
            }
            
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public T GetItem(object id)
        {
            return DbSet.Find(id);
        }

        public void Create(T item)
        {
            DbSet.Add(item);
        }

        public void Update(T item)
        {
            DbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var item = DbSet.Find(id);
            DbSet.Remove(item);
        }
    }
}