// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {

        public static IEnumerable<ApiResource> ApiResources
        {
            get
            {
                return new List<ApiResource>
                {
                    new ApiResource("CatalogResource")
                    {
                        Scopes = { "CatalogFullPermission" , "CatalogReadPermission"}
                    },
                    new ApiResource("DiscountResource")
                    {
                        Scopes = { "DiscountFullPermission"}
                    },
                    new ApiResource("OrderResource")
                    {
                        Scopes = { "OrderFullPermission"}
                    },
                    new ApiResource("CargoResource")
                    {
                        Scopes = { "CargoFullPermission"}
                    },
                    new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
                };
            }
        }

        public static IEnumerable<IdentityResource> IdentityResources
        {
            get
            {
                return new List<IdentityResource>
                {
                    new IdentityResources.OpenId(),
                    new IdentityResources.Email(),
                    new IdentityResources.Profile(),
                };
            }
        }

        public static IEnumerable<ApiScope> ApiScopes
        {
            get
            {
                return new List<ApiScope>
                {
                    new ApiScope("CatalogFullPermission", "Full permission to catalog API"),
                    new ApiScope("CatalogReadPermission", "Read permission to catalog API"),
                    new ApiScope("DiscountFullPermission", "Full permission to discount API"),
                    new ApiScope("OrderFullPermission", "Full permission to order API"),
                    new ApiScope("CargoFullPermission", "Full permission to cargo API"),
                    new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
                };
            }
        }

        public static IEnumerable<Client> Clients
        {
            get
            {
                return new List<Client>
                {
                    // Visitor
                    new Client
                    {
                        ClientId = "MultiShopVisitor",
                        ClientName = "MultiShop Visitor User",
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        ClientSecrets = { new Secret("multishopsecret".Sha256())},
                        AllowedScopes = { "DiscountFullPermission" }
                    },

                    // Manager
                    new Client
                    {
                        ClientId = "MultiShopManager",
                        ClientName = "MultiShop Manager User",
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        ClientSecrets = { new Secret("multishopsecret".Sha256())},
                        AllowedScopes = { "CatalogFullPermission",
                            "CatalogReadPermission" }
                    },

                    // Admin
                    new Client
                    {
                        ClientId = "MultiShopAdmin",
                        ClientName = "MultiShop Admin User",
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        ClientSecrets = { new Secret("multishopsecret".Sha256())},
                        AllowedScopes = { "CatalogFullPermission",
                            "CatalogReadPermission",
                            "DiscountFullPermission",
                            "OrderFullPermission",
                            "CargoFullPermission",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.LocalApi.ScopeName
                        },
                        AccessTokenLifetime = 600,
                    },
                };
            }
        }

    }
}