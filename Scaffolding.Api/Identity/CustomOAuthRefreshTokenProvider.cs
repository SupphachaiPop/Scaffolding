using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using System.Collections.Concurrent;
using Microsoft.Owin.Security.Infrastructure;

namespace Scaffolding.Api.Identity
{
    public class CustomOAuthRefreshTokenProvider : AuthenticationTokenProvider
    {
        private readonly int _utcHours;
        private static ConcurrentDictionary<string, AuthenticationTicket> _refreshTokens = new ConcurrentDictionary<string, AuthenticationTicket>();

        public CustomOAuthRefreshTokenProvider(int utcHours)
        {
            this._utcHours = utcHours;
        }

        #region[CreateAsync]
        public override async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var guid = Guid.NewGuid().ToString();
            /* Copy claims from previous token
             ***********************************/
            var refreshTokenProperties = new AuthenticationProperties(context.Ticket.Properties.Dictionary)
            {
                IssuedUtc = context.Ticket.Properties.IssuedUtc.Value.AddHours(this._utcHours),
                ExpiresUtc = DateTime.UtcNow.AddHours(this._utcHours).AddMinutes(40)
            };
            var refreshTokenTicket = await Task.Run(() => new AuthenticationTicket(context.Ticket.Identity, refreshTokenProperties));

            _refreshTokens.TryAdd(guid, refreshTokenTicket);

            // consider storing only the hash of the handle  
            context.SetToken(guid);
        }
        #endregion

        #region[ReceiveAsync]
        public override async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            AuthenticationTicket ticket;
            string header = await Task.Run(() => context.OwinContext.Request.Headers["Authorization"]);

            if (_refreshTokens.TryRemove(context.Token, out ticket))
                context.SetTicket(ticket);
        }
        #endregion

        #region[Create & Receive Synchronous methods]
        public override void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }
        public override void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}