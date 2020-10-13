using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Scaffolding.ViewModels;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Routing;
using Microsoft.Web.Http.Routing;
using Microsoft.Web.Http;
using Microsoft.Web.Http.Versioning;

namespace Scaffolding.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            //config.MessageHandlers.Add(new PreflightRequestsHandler());

            // Add DefaultInlineConstraintResolver
            var constraintResolver = new DefaultInlineConstraintResolver()
            {
                ConstraintMap =
                {
                    ["apiVersion"] = typeof( ApiVersionRouteConstraint )
                }
            };
            config.MapHttpAttributeRoutes(constraintResolver);

            // Add ApiVersioning configuration
            config.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.ApiVersionReader = new HeaderApiVersionReader("api-version");
                o.ApiVersionSelector = new CurrentImplementationApiVersionSelector(o);
                o.ErrorResponses = new CustomErrorResponseProvider();
            });

            // Add Authorize attribute Filter 
            //config.Filters.Add(new System.Web.Http.AuthorizeAttribute());

            // Add JsonFormatter convert all property name to lowercase (Web API response)
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new LowercaseContractResolver();
        }
    }

    public class CustomErrorResponseProvider : DefaultErrorResponseProvider
    {
        // note: in Web API the response type is HttpResponseMessage
        public override HttpResponseMessage CreateResponse(ErrorResponseContext context)
        {
            switch (context.ErrorCode)
            {
                case "UnsupportedApiVersion":
                    context = new ErrorResponseContext(
                        context.Request,
                        context.StatusCode,
                        context.ErrorCode,
                        "My custom error message.",
                        context.MessageDetail);
                    break;
            }

            return base.CreateResponse(context);
        }
    }

    public class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }

    public class PreflightRequestsHandler : DelegatingHandler
    {
        private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
        {
            token = null;
            IEnumerable<string> authzHeaders;
            if (!request.Headers.TryGetValues("Authorization", out authzHeaders) || authzHeaders.Count() > 1)
            {
                return false;
            }
            var bearerToken = authzHeaders.ElementAt(0);
            token = (bearerToken.ToLower().StartsWith("bearer ") ? bearerToken.Substring(7) : bearerToken);
            return true;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpStatusCode statusCode;
            string errMessage = null;
            string token;

            try
            {
                // Validate jwt exists or not
                if (!TryRetrieveToken(request, out token))
                {
                    throw new SecurityTokenValidationException();
                }

                var issuer = ConfigurationManager.AppSettings["jwt_issuer"];
                var audience = ConfigurationManager.AppSettings["jwt_audience"];
                var secret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["jwt_secret"]);
                var securityKey = new SymmetricSecurityKey(secret);

                SecurityToken securityToken;
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                TokenValidationParameters validationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    LifetimeValidator = this.LifetimeValidator,
                    IssuerSigningKey = securityKey
                };

                // Extract and assign the user of the jwt 
                Thread.CurrentPrincipal = handler.ValidateToken(token, validationParameters, out securityToken);
                HttpContext.Current.User = handler.ValidateToken(token, validationParameters, out securityToken);
                return base.SendAsync(request, cancellationToken);
            }
            catch (SecurityTokenValidationException e)
            {
                statusCode = HttpStatusCode.Unauthorized;
                errMessage = statusCode.ToString();
            }
            catch (Exception ex)
            {
                statusCode = HttpStatusCode.InternalServerError;
                errMessage = ex.Message;
            }

            return Task<HttpResponseMessage>.Factory.StartNew(() => request.CreateResponse<VMBASE_RESPONSE_STATUS>(statusCode, new VMBASE_RESPONSE_STATUS()
            {
                IS_SUCCESS = false,
                MESSAGE = errMessage
            }));
        }

        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }
    }
}
