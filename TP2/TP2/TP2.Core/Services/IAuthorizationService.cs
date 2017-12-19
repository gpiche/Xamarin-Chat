using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TP2.Core.Domain;

namespace TP2.Core.Services
{
    public interface IAuthorizationService
    {
        Task<AccessToken> AuthenticateAsync(string username, string password);
    }
}
