using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        DbContext db;
        IDbSet<T> dbSet;

        public BaseRepository(DbContext db)
        {
            this.db = db;
            dbSet = db.Set<T>();
        }

        public void Create(T obj)
        {
            dbSet.Add(obj);
            db.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }

        public T Get(int id)
        {
            T t = dbSet.Single(x=>x.id == id);
            return t;
        }

        public void Update(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var itemToRemove = dbSet.SingleOrDefault(x => x.id == id); //returns a single item.

            if (itemToRemove != null)
            {
                dbSet.Remove(itemToRemove);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
