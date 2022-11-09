using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BTAPI.Responsitory
{
    public interface IRepository<T> where T : class, new()
    {
        IEnumerable<T> GetAll();
        CommonResponseDto GetById(object id);
        CommonResponseDto AddOrUpdate(T entity,object id);
        CommonResponseDto Remove(object id);
    }
}
