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
    [RoutePrefix("api/Product")]
    public class ProductApiController : ApiController
    {
        private IRepository<Product> product;
        public ProductApiController()
        {
            product = new Repository<Product>();
        }
        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var ret = new CommonResponseDto();
            try
            {
                var data = product.GetAll();
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
