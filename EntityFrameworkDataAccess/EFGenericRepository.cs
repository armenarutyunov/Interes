
using DBMOD;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDataAccess
{
    public interface IDataRepository<T>
    {
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        IList<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);
        T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);
        void Add(params T[] items);
        void Update(params T[] items);
        void Remove(params T[] items);
    }
    public class EFGenericRepository<T> : IDataRepository<T> where T : class
    {

        public RestaurantEntities _context;
        public EFGenericRepository(bool createProxy = true)
        {
            // _context = new DBModelContainer(createProxy);
            _context = new RestaurantEntities();

        }

        public virtual void Add(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State = System.Data.Entity.EntityState.Added;
            }
            _context.SaveChanges();
        }

        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();
            foreach (Expression<Func<T, object>> navProp in navigationProperties)
            {
                dbQuery = dbQuery.Include<T, object>(navProp);
            }
            return dbQuery.ToList();
        }

        public IList<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();
            foreach (Expression<Func<T, object>> navProp in navigationProperties)
            {
                dbQuery = dbQuery.Include<T, object>(navProp);
            }
            return dbQuery.Where(where).ToList();
        }

        public T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();
            foreach (Expression<Func<T, object>> navProp in navigationProperties)
            {
                dbQuery = dbQuery.Include<T, object>(navProp);
            }
            //return dbQuery.Where(where).FirstOrDefault();
            return dbQuery.FirstOrDefault(where);
        }

        public void Remove(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
            }
            _context.SaveChanges();
        }

        public virtual void Update(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State = System.Data.Entity.EntityState.Modified;

            }
            _context.SaveChanges();
        }
    }

}
