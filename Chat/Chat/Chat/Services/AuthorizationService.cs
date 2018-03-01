using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Chat.Domain;
using IdentityModel.Client;

namespace Chat.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        public async Task<AccessToken> AuthenticateAsync(string username, string password)
        {
            var tokenClient = new TokenClient(GlobalSetting.Instance.TokenEndpoint, GlobalSetting.Instance.ClientId, GlobalSetting.Instance.ClientSecret);
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(username, password, GlobalSetting.Instance.ApiScope);

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
               
            }
            return new AccessToken(tokenResponse.AccessToken);
        }
    }
}
