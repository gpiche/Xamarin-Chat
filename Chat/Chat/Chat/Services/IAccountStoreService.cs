using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Services
{
    public interface IAccountStoreService
    {
        void SaveCredentials(string userName, string accessToken);
    }
}
