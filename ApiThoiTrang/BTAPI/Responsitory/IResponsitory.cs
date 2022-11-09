using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace API.Responsitory
{
    public interface IRepository<T> where T : class, new()
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetNoTracking(Expression<Func<T, bool>> predicate);
        T GetById(object id);
        IEnumerable<T> GetInclude(string include);

        bool Add(T entity);
        bool Edit(T entity);
        bool Remove(object id);
    }
}
