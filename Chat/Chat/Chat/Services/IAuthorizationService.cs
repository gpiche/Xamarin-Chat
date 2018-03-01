using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Chat.Domain;

namespace Chat.Services
{
    public interface IAuthorizationService
    {
        Task<AccessToken> AuthenticateAsync(string username, string password);
    }
}
