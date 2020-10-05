using Scaffolding.Api.Controllers.Base.v1;
using Scaffolding.Application;
using Scaffolding.ViewModels;
using Microsoft.Web.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Scaffolding.Api.Controllers.v1
{
    //[Authorize]
    [ApiVersion("1.0")]
    [RoutePrefix("api/v{version:apiVersion}/category")]
    public class CategoryController : BaseApiController
    {
        private IDataApplication _dataApplication;
        public CategoryController(IDataApplication dataApplication)
        {
            this._dataApplication = dataApplication;
        }


    }
}