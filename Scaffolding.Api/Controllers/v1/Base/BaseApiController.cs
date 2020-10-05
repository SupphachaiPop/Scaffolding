using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Scaffolding.Api.Controllers.Base.v1
{
    public class BaseApiController : ApiController
    {
        public BaseApiController() { }

        public string GetTokenFromHeader()
        {
            string result = string.Empty;
            var authentication = Request.Headers.Authorization;
            if (authentication != null && !string.IsNullOrEmpty(authentication.Parameter))
            {
                result = authentication.Parameter.ToString();
            }
            return result;
        }
    }
}