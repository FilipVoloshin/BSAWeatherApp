using BSAWeatherApp.Services;
using System.Collections.Generic;
using System.Data.Entity;

namespace BSAWeatherApp.DataService
{
    public class Repository<T> : IRepository<T>
        where T : class, IEntity
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

        public T GetItem(int id)
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