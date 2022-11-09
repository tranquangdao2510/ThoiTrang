using BTAPI.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace BTAPI.Responsitory
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
        public  CommonResponseDto AddOrUpdate(T entity,object id)
        {
            CommonResponseDto dto = new CommonResponseDto();
            try
            {
                if (id == null)
                {
                    tbl.Add(entity);
                    db.SaveChanges();
                    dto.Code = CommonEnum.ResponseCodeStatus.ThanhCong;
                    dto.Message = string.Empty;
                }
                else
                {
                    db.Entry(entity).State = EntityState.Modified;
                    db.SaveChanges();
                    dto.Code = CommonEnum.ResponseCodeStatus.ThanhCong;
                    dto.Message = string.Empty;
                }
            }
            catch (Exception ex)
            {
                dto.ErrorCode = ex.Message;
            }
            return dto;
        }
        public IEnumerable<T> GetAll()
        {
            return tbl.AsNoTracking().AsEnumerable();
        }

        public CommonResponseDto GetById(object id)
        {
            CommonResponseDto dto = new CommonResponseDto();
            try
            {
               var byId = tbl.Find(id);
                dto.Code = CommonEnum.ResponseCodeStatus.ThanhCong;
                dto.Message = string.Empty;
                dto.ReturnValue = byId;
            }
            catch (Exception ex)
            {
                dto.Message = ex.Message;
            }
            return dto;
        }

        public CommonResponseDto Remove(object id)
        {
            CommonResponseDto dto = new CommonResponseDto();
            try
            {
                var entity = GetById(id);
                tbl.Remove((T)entity.ReturnValue);
                db.SaveChanges();
                dto.Code = CommonEnum.ResponseCodeStatus.ThanhCong;
                dto.Message = string.Empty;
            }
            catch (Exception ex)
            {
                dto.ErrorCode = ex.Message;
            }
            return dto;
        }
    }
}