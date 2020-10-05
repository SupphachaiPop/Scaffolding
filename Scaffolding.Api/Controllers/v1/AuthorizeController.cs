using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Scaffolding.Api.Controllers.Base.v1;
using Scaffolding.Application;
using Scaffolding.ViewModels;
using Microsoft.Web.Http;
using Newtonsoft.Json;

namespace Scaffolding.Api.Controllers.v1
{
    //[Authorize]
    [ApiVersion("1.0")]
    [RoutePrefix("api/v{version:apiVersion}/authorize")]
    public class AuthorizeController : BaseApiController
    {
        private IDataApplication _dataApplication;
        public AuthorizeController(IDataApplication dataApplication)
        {
            this._dataApplication = dataApplication;
        }

        #region [Public Methods: Admin V1]   
        //[HttpPost]
        //[Route("admin/token")]
        //public IHttpActionResult requestAdminToken([FromBody]MGTS_ADMIN_TOKEN_PARAM param)
        //{
        //    var res = this._dataApplication.AdminToken_v1(param: param);
        //    return Ok(res);
        //}
        #endregion [Public Methods: Admin V1] 

        #region [Public Methods: Customer V1]   
        //[HttpPost]
        //[Route("customer/token")]
        //public IHttpActionResult requestCustomerToken([FromBody]MGTS_CUS_TOKEN_PARAM param)
        //{
        //    var res = this._dataApplication.CustomerToken_v1(param: param);
        //    return Ok(res);
        //}
        #endregion [Public Methods: Customer V1] 
    }
}
