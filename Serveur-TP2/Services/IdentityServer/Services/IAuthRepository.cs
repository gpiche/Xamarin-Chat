using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer.Models;

namespace IdentityServer
{
    public interface IAuthRepository
    {
        User GetUserById(string id);
        User GetUserByUsername(string username);
        bool ValidatePassword(string username, string plainTextPassword);
        void Add(User user);


    }
}
