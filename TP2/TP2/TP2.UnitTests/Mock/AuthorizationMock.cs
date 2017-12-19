using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Core.Domain;
using TP2.Core.Services;

namespace TP2.UnitTests.Mock
{
    class AuthorizationMock : IAuthorizationService
    {
        public Task<AccessToken> AuthenticateAsync(string username, string password)
        {
            if (password == "Valid Password" & username == "Valid UserName")
            {
                return Task.FromResult(new AccessToken("token"));
            }

            return Task.FromResult(new AccessToken(null));

        }
    }
}
