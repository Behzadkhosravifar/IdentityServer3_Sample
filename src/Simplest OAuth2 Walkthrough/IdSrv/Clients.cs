﻿using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdSrv
{
    static class Clients
    {
        public static List<Client> Get()
        {
            return new List<Client>
            {
                // no human involved
                new Client
                {
                    ClientName = "Silicon-only Client",
                    ClientId = "silicon",
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Jwt,

                    Flow = Flows.ClientCredentials,
                    
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("F621F470-9731-4A25-80EF-67A6F7C5F4B8".Sha256())
                    },
                    
                    AllowedScopes = new List<string>
                    {
                        "api1"
                    },

                    Claims = new List<Claim>
                    {
                        new Claim(Constants.ClaimTypes.Role, "account:get"),
                        new Claim(Constants.ClaimTypes.Role, "account:add"),
                        new Claim(Constants.ClaimTypes.Role, "account:change"),
                        new Claim(Constants.ClaimTypes.Role, "device:get")
                    },
                    AllowAccessToAllScopes = true,
                    PrefixClientClaims = false
                },

                new Client
                {
                    ClientName = "Test for multiple client secrets",
                    ClientId = "behzad",
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Reference,

                    Flow = Flows.ClientCredentials,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("21B5F798-BE55-42BC-8AA8-0025B903DC3B".Sha256()),
                        new Secret("F621F470-9731-4A25-80EF-67A6F7C5F4B8".Sha256())
                    },

                    AllowedScopes = new List<string>
                    {
                        "api1"
                    }
                },

                // human is involved
                new Client
                {
                    ClientName = "Silicon on behalf of Carbon Client",
                    ClientId = "carbon",
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Reference,

                    Flow = Flows.ResourceOwner,
                    
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("21B5F798-BE55-42BC-8AA8-0025B903DC3B".Sha256()),
                        new Secret("F621F470-9731-4A25-80EF-67A6F7C5F4B8".Sha256())
                    },

                    AllowedScopes = new List<string>
                    {
                        "api1"
                    }
                }
            };
        }
    }
}