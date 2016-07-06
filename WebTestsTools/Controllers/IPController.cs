using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebTestsTools.Controllers
{

    public class IPController : ApiController
    {
        [Route("ip")]
        public string Get()
        {
            return HttpContext.Current.Request.UserHostAddress.ToString();
        }
    }
}
