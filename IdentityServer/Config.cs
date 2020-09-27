// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> Apis =>
            new List<ApiResource>
            {
                new ApiResource("CustomerService.API", "Customer API")
                    {Scopes = {"CustomerService.API"}},
                new ApiResource("AccountService.API", "Accounts API")
                    {Scopes = {"AccountService.API"}},
                new ApiResource("StatementService.API", "Statements API")
                    {Scopes = {"StatementService.API"}},
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("CustomerService.API", "Customer API"),
                new ApiScope("AccountService.API", "Accounts API"),
                new ApiScope("StatementService.API", "Statements API"),
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client {
                    ClientId = "swagger.api",
                    ClientName = "Swagger UI",
                    ClientSecrets = {new Secret("secret".Sha256())}, // change me!
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris =
                    {
                        "https://localhost:5002/swagger/oauth2-redirect.html",
                        "https://localhost:5003/swagger/oauth2-redirect.html",
                        "https://localhost:5004/swagger/oauth2-redirect.html"
                    },
                    AllowedCorsOrigins =
                    {
                        "https://localhost:5002",
                        "https://localhost:5003",
                        "https://localhost:5004"
                    },
                    AllowedScopes =
                    {
                        "CustomerService.API",
                        "AccountService.API",
                        "StatementService.API"
                    }
                },

                // uncomment for every api
                //new Client
                //{
                //    ClientId = $"CustomerService.API",
                //    AllowedGrantTypes = GrantTypes.Code,
                //    ClientSecrets =
                //    {
                //        new Secret("secret".Sha256())
                //    },
                //    AllowedScopes = {$"CustomerService.API"}
                //},
                //new Client
                //{
                //    ClientId = $"AccountService.API",
                //    AllowedGrantTypes = GrantTypes.Code,
                //    ClientSecrets =
                //    {
                //        new Secret("secret".Sha256())
                //    },
                //    AllowedScopes = {$"AccountService.API"}
                //},
                //new Client
                //{
                //    ClientId = $"StatementService.API",
                //    AllowedGrantTypes = GrantTypes.Code,
                //    ClientSecrets =
                //    {
                //        new Secret("secret".Sha256())
                //    },
                //    AllowedScopes = {$"StatementService.API"}
                //},
            };
    }
}