using System;
using System.Configuration;
using System.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Scaffolding.Api.Identity
{
    public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private readonly byte[] _secret;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _utcHours;

        public CustomJwtFormat(string issuer, string audience, string secret, int utcHours)
        {
            this._issuer = issuer;
            this._audience = audience;
            this._secret = TextEncodings.Base64Url.Decode(secret);
            this._utcHours = utcHours;
        }

        public CustomJwtFormat(string issuer, string audience, byte[] secret, int utcHours)
        {
            this._issuer = issuer;
            this._audience = audience;
            this._secret = secret;
            this._utcHours = utcHours;
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var signingKey = new SigningCredentials(new SymmetricSecurityKey(this._secret), SecurityAlgorithms.HmacSha256);
            var issued = data.Properties.IssuedUtc.Value.AddHours(this._utcHours);
            var expires = data.Properties.ExpiresUtc.Value.AddHours(this._utcHours);

            return new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(this._issuer, this._audience, data.Identity.Claims, issued.DateTime, expires.DateTime, signingKey));
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}