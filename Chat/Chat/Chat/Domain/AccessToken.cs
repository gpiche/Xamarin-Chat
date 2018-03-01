using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Domain
{
    public class AccessToken
    {
        public bool IsNullOrEmpty => string.IsNullOrEmpty(Token);

        public string Token { get; }

        public AccessToken(string accessToken)
        {
            Token = accessToken;
        }
    }
}
