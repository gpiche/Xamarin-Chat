using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IdentityModel.Client;
using TP2.Core.Domain;

namespace TP2.Core.Services
{
    class AuthorizationService : IAuthorizationService
    {

        public async Task<AccessToken> AuthenticateAsync(string username, string password)
        {
            var tokenClient = new TokenClient(GlobalSetting.Instance.TokenEndpoint, GlobalSetting.Instance.ClientId, GlobalSetting.Instance.ClientSecret);
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(username, password, GlobalSetting.Instance.ApiScope);
            return new AccessToken(tokenResponse.AccessToken);
         
        }
    }
}
