using Autofac;
using Autofac.Core.Lifetime;
using Autofac.Integration.Mvc;
using AutoMapper;
using System.Reflection;
using Hangfire;
using Scaffolding.Common;
using Scaffolding.Application;
using Scaffolding.Application.AutoMapper;
using Scaffolding.Data.Repositories;
using Scaffolding.Domain;
using Autofac.Integration.WebApi;
using System.Web.Http;
using Scaffolding.Data;

namespace Scaffolding.Api
{
    public static class AutofacConfig
    {
        public static IContainer Excute(HttpConfiguration config)
        {
            return SetAutofacContainer(config);
        }

        private static IContainer SetAutofacContainer(HttpConfiguration config)   
        {
            var requestTag = MatchingScopeLifetimeTags.RequestLifetimeScopeTag;
            var jobTag = AutofacJobActivator.LifetimeScopeTag;

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<EFUnitOfWork>().As<IEFUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterInstance(AutoMapperServiceConfiguration.Mapper)
                .As<IMapper>()
                .SingleInstance();

            builder.RegisterAssemblyTypes(typeof(UtilityCommon).Assembly)
                .Where(t => t.Name.EndsWith("Common"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(userRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(DataDomain).Assembly)
               .Where(t => t.Name.EndsWith("Domain"))
               .AsImplementedInterfaces()
               .InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(DataApplication).Assembly)
               .Where(t => t.Name.EndsWith("Application"))
               .AsImplementedInterfaces()
               .InstancePerRequest();

            IContainer container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return container;

            // Set the dependency resolver for Web API.
            //var webApiResolver = new AutofacWebApiDependencyResolver(container);
            //System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;
        }
    }

}
