using System;
using System.Collections.Generic;
using System.Text;

namespace TP2.Core
{
    public class GlobalSetting
    {
        public const string DefaultEndpoint = "http://192.168.99.100";

        private string _baseEndpoint;

        public GlobalSetting()
        {
            BaseEndpoint = DefaultEndpoint;
        }

        public static GlobalSetting Instance { get; } = new GlobalSetting();

        public string BaseEndpoint
        {
            get => _baseEndpoint;
            set
            {
                _baseEndpoint = value;
                UpdateEndpoint(_baseEndpoint);
            }
        }

        // Attention ! 
        public string ClientId => "ro.client";
        public string ClientSecret => "secret";
        public string ApiScope => "api1";

        public string AuthorizationEndpoint { get; set; }
        public string JwksUri { get; set; }
        public string LogoutEndpoint { get; set; }
        public string TokenEndpoint { get; set; }
        public string UserInfoEndpoint { get; set; }
        public string IdentityEndpoint { get; set; }
        public string RestApiEndPoint { get; set; }

        private void UpdateEndpoint(string baseEndpoint)
        {
            //Api 
            RestApiEndPoint = $"{baseEndpoint}:5001/api";

            //Identity server
            IdentityEndpoint = $"{baseEndpoint}:5000";
            IdentityEndpoint = $"{baseEndpoint}:5000";
            TokenEndpoint = $"{baseEndpoint}:5000/connect/token";
            UserInfoEndpoint = $"{baseEndpoint}:5000/connect/userinfo";
            LogoutEndpoint = $"{baseEndpoint}:5000/connect/endsession";
            JwksUri = $"{baseEndpoint}:5000/.well-known/openid-configuration/jwks";
            AuthorizationEndpoint = $"{baseEndpoint}:5000/connect/authorize";
        }
    }
}

