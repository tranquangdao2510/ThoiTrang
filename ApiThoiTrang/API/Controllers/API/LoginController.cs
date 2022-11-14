using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers.API
{

    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("login_test")]
        public IHttpActionResult Login()
        {
            return Ok("aaaa");
        }

    }
}
