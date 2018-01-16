using System;
using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServerQuickStarts
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")

                {
                    UserClaims = new List<String>
                    {
                        ClaimTypes.NameIdentifier
                    }
                }

            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "a",
                    Password = "a",
                    Claims = new []
                    {
                        new Claim(ClaimTypes.NameIdentifier, "a")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "b",
                    Password = "b",
                    Claims = new []
                    {
                        new Claim(ClaimTypes.NameIdentifier, "b"), 
                    }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedCorsOrigins = {"http://localhost:55167"},
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api1" }
                }

            };
        }
    }
}
