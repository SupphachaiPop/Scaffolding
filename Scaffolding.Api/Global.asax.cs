using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using Scaffolding.Application.AutoMapper;

namespace Scaffolding.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // AutoMapper
            AutoMapperServiceConfiguration.Configure();

            // Custom Machine key for Azure
            var mksType = typeof(MachineKeySection);
            var mksSection = ConfigurationManager.GetSection("system.web/machineKey") as MachineKeySection;
            var resetMethod = mksType.GetMethod("Reset", BindingFlags.NonPublic | BindingFlags.Instance);

            var newConfig = new MachineKeySection();
            newConfig.ApplicationName = mksSection.ApplicationName;
            newConfig.CompatibilityMode = mksSection.CompatibilityMode;
            newConfig.DataProtectorType = mksSection.DataProtectorType;
            newConfig.Validation = mksSection.Validation;

            newConfig.ValidationKey = ConfigurationManager.AppSettings["Scaffolding.MK_ValidationKey"];
            newConfig.DecryptionKey = ConfigurationManager.AppSettings["Scaffolding.MK_DecryptionKey"];
            newConfig.Decryption = ConfigurationManager.AppSettings["Scaffolding.MK_Decryption"];                   // default: AES
            newConfig.ValidationAlgorithm = ConfigurationManager.AppSettings["Scaffolding.MK_ValidationAlgorithm"]; // default: SHA1

            resetMethod.Invoke(mksSection, new object[] { newConfig });
        }
    }
}
