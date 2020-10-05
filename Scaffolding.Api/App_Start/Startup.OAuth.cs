using System;
using System.Configuration;
using Scaffolding.Data;
using Scaffolding.Api.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.Infrastructure;
using Owin;

namespace Scaffolding.Api
{
    public partial class Startup
    {
        public void ConfigureOAuth(IAppBuilder app)
        {
            var issuer = ConfigurationManager.AppSettings["jwt_issuer"];
            var audience = ConfigurationManager.AppSettings["jwt_audience"];
            var secret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["jwt_secret"]);
            var utcHours = Convert.ToInt16(ConfigurationManager.AppSettings["jwt_utchours"]);
            var expireHours = Convert.ToInt16(ConfigurationManager.AppSettings["jwt_expirehours"]);

            app.CreatePerOwinContext(() => new DBEntities());

            // Enabling Bearer Authentication/Authorization
            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                AllowedAudiences = new[] { "Any" },
                IssuerSecurityKeyProviders = new IIssuerSecurityKeyProvider[]
                {
                    new SymmetricKeyIssuerSecurityKeyProvider(issuer, secret)
                }
            });

            // Enabling OAuth
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/authorize/token"),
                Provider = new CustomOAuthProvider(),
                AccessTokenFormat = new CustomJwtFormat(issuer, audience, secret, utcHours),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(expireHours)
            });

            //app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            //{
            //    AllowInsecureHttp = true,
            //    TokenEndpointPath = new PathString("/authorize/token"),
            //    Provider = new CustomOAuthProvider(),
            //    AccessTokenFormat = new CustomJwtFormat(issuer, audience, secret, utcHours),
            //    AccessTokenExpireTimeSpan = TimeSpan.FromHours(expireHours),
            //    RefreshTokenProvider = new CustomOAuthRefreshTokenProvider(utcHours)
            //});

            // Init OauthBearer
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}