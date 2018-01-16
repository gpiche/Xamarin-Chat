using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public interface ICryptoService
    {
        string GenerateSalt();
        string HashSha512(string value, string salt);
    }
}
