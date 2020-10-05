using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(Scaffolding.Api.Startup))]
namespace Scaffolding.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);

            // Register HttpConfig
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);

            // Autofac configurations
            var container = AutofacConfig.Excute(config);

            // Init AppBuilder
            app.UseCors(CorsOptions.AllowAll);
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
        }
    }
}