using API.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace API.Responsitory
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {

        private DbConn db;
        private DbSet<T> tbl;
        public Repository()
        {
            db = new DbConn();
            tbl = db.Set<T>();
        }
        public bool Add(T entity)
        {
            try
            {
                tbl.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(T entity)
        {
            try
            {
                
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return tbl.Where(predicate).AsEnumerable();
        }

        public IEnumerable<T> GetAll()
        {
            return tbl.AsNoTracking().AsEnumerable();
            //return tbl.AsEnumerable();
        }

        public T GetById(object id)
        {
            return tbl.Find(id);
        }

        public IEnumerable<T> GetInclude(string include)
        {

            var data = tbl.AsQueryable();
            string[] includes = include.Split(',');
            foreach (var item in includes)
            {
                data = data.Include(item);
            }
            return data;
        }

        public IEnumerable<T> GetNoTracking(Expression<Func<T, bool>> predicate)
        {
            return tbl.Where(predicate).AsNoTracking().AsEnumerable();
        }

        public bool Remove(object id)
        {
            try
            {
                var entity = GetById(id);
                tbl.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}