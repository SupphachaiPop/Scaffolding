using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Scaffolding.Api.Controllers.Base.v2;
using Scaffolding.Application;
using Scaffolding.ViewModels;
using Microsoft.Web.Http;
using Newtonsoft.Json;

namespace Scaffolding.Api.Controllers.v2
{
    [Authorize]
    [ApiVersion("2.0")]
    [RoutePrefix("api/v{version:apiVersion}/product")]
    public class ProuductController : BaseApiController
    {
        private IDataApplication _dataApplication;
        public ProuductController(IDataApplication dataApplication)
        {
            this._dataApplication = dataApplication;
        }

        #region [Public Methods: V2]   

       
        #endregion [Public Methods: V2] 
    }
}
