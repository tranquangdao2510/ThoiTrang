using API.Models.Entity;
using API.Responsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BTAPI.Controllers.API
{
    [RoutePrefix("api/Customer")]
    public class CustomerApiController : ApiController
    {
        public IRepository<Customer> Table;
        public CustomerApiController()
        {
            Table = new Repository<Customer>();
        }
        //[HttpPost]
        //[Route("Them_moi_nguoi_dung")]
        public IHttpActionResult Create(Customer input)
        {
            var ret = new CommonResponseDto();
            try
            {
                var data = Table.Add(input);
                ret.Code = CommonEnum.ResponseCodeStatus.ThanhCong;
                ret.Message = string.Empty;
                ret.ReturnValue = data;
            }
            catch (Exception ex)
            {
                ret.Code = CommonEnum.ResponseCodeStatus.ThatBai;
                ret.Message = ex.Message;
            }
            return Ok(ret);
        }
        //[HttpPost]
        //[Route("Sua_nguoi_dung")]
        public IHttpActionResult Edit(Customer input)
        {
            var ret = new CommonResponseDto();
            try
            {
                var data = Table.Edit(input);
                ret.Code = CommonEnum.ResponseCodeStatus.ThanhCong;
                ret.Message = string.Empty;
                ret.ReturnValue = data;
            }
            catch (Exception ex)
            {
                ret.Code = CommonEnum.ResponseCodeStatus.ThatBai;
                ret.Message = ex.Message;
            }
            return Ok(ret);
        }
    }
}
