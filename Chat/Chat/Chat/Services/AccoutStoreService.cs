using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Auth;

namespace Chat.Services
{
    public class AccoutStoreService : IAccountStoreService
    {
        public void SaveCredentials(string userName, string accessToken)
        {
            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(accessToken))
            {
                Account account = new Account
                {
                    Username = userName
                };
               account.Properties.Add("token", accessToken);
                AccountStore.Create().Save(account, App.AppNAme);
            }
        }
    }
}
