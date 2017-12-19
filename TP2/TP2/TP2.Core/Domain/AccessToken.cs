using System;
using System.Collections.Generic;
using System.Text;

namespace TP2.Core.Domain
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
