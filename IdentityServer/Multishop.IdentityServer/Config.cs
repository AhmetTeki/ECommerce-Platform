﻿using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4;

namespace Multishop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog")
            {
                Scopes = { "CatalogFullPermission", "CatalogReadPermission" }
            },
            new ApiResource("ResourceDiscount")
            {
                Scopes = { "DiscountFullPermission" }
            },
            new ApiResource("ResourceOrder")
            {
                Scopes = { "OrderFullPermission" }
            },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
             new IdentityResources.OpenId(),
             new IdentityResources.Email(),
             new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission", "Full authority for catalog oparations"),
            new ApiScope("CatalogReadPermission", "Reading authority for catalog oparations"),
            new ApiScope("DiscountFullPermission", "Full authority for discount oparations"),
            new ApiScope("OrderFullPermission", "Full authority for order oparations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor
            new Client
            {
                ClientId = "MultishopVisitorId",
                ClientName = "Multishop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("multishopsecret".Sha256()) },
                AllowedScopes = { "DiscountFullPermission" }
            },
            
            //Manager
            new Client
            {
            ClientId = "MultishopManagerId",
            ClientName = "Multishop Manager User",
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            ClientSecrets = { new Secret("multishopsecret".Sha256()) },
            AllowedScopes = {"CatalogFullPermission"}
            },
            
            //Admin
            new Client
            {
                ClientId = "MultishopAdminId",
                ClientName = "Multishop Admin User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("multishopsecret".Sha256()) },
                AllowedScopes =
                {
                    "CatalogFullPermission" , "DiscountFullPermission" , "OrderFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                },
                AccessTokenLifetime = 600
            }
        };
    }
}