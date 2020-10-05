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

    [ApiVersion("1.0")]
    [RoutePrefix("api/v{version:apiVersion}/cart")]
    public class CartController : BaseApiController
    {
        private IDataApplication _dataApplication;
        public CartController(IDataApplication dataApplication)
        {
            this._dataApplication = dataApplication;
        }

        #region [Public Methods: V1]   

        #endregion [Public Methods: V1] 
    }
}