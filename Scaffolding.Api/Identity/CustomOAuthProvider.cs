using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Autofac.Integration.Mvc;
using Scaffolding.Application;
using Scaffolding.Data;
using Scaffolding.Models;
using System.Data.Entity;
using Scaffolding.Common;
using System.Collections.Generic;

namespace Scaffolding.Api.Identity
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            UtilityCommon util = new UtilityCommon();
            ConfigurationCommon config = new ConfigurationCommon();

            string passwordEncryptionkey = config.Setting<string>("password_encryptionkey");
            string staticUsername = config.Setting<string>("static_username");
            string staticPassword = config.Setting<string>("static_password");

            string encryptedContextPassword = util.MD5HashWithKey(input: context.Password, Encryptionkey: passwordEncryptionkey);
            string encryptedStaticPassword = util.MD5HashWithKey(input: staticPassword, Encryptionkey: passwordEncryptionkey);
            if (context.UserName == staticUsername &&
                encryptedContextPassword == encryptedStaticPassword)
            {
                var ticket = new AuthenticationTicket(SetClaimsIdentity(context), new AuthenticationProperties());
                context.Validated(ticket);

                return Task.FromResult<object>(null);
            }
            else
            {
                context.SetError("invalid_grant", "The user name or password is incorrect");
                context.Rejected();
                return Task.FromResult<object>(null);
            }
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            //if (context.ClientId == null)
            //    context.Validated();

            context.Validated();
            return Task.FromResult<object>(null);
        }

        private static ClaimsIdentity SetClaimsIdentity(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity("JWT");
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            return identity;
        }

        #region[GrantRefreshToken]
        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            // Change authentication ticket for refresh token requests  
            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);
            // newIdentity.AddClaim(new Claim("newClaim", "newValue"));

            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);

            return Task.FromResult<object>(null);
        }
        #endregion

        #region[TokenEndpoint]
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            // Add response parameters when request token
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
        #endregion
    }
}