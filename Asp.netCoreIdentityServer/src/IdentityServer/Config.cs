// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4;
namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId(),
                  new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {         new ApiScope("emrapi", "EMR API")
  };

        public static IEnumerable<Client> Clients =>

        //Asp.net core emr Api
            new Client[] 
            {        new Client
        {
            ClientId = "ro.emr",

            // no interactive user, use the clientid/secret for authentication
            AllowedGrantTypes = GrantTypes.ClientCredentials,

            // secret for authentication
            ClientSecrets =
            {
                new Secret("emrsecret".Sha256())
            },

            // scopes that client has access to
            AllowedScopes = { "emrapi" }
        },
          // interactive EMR MVC client
        new Client
        {
            ClientId = "ro.emrmvc",
            ClientSecrets = { new Secret("emrsecret".Sha256()) },

            AllowedGrantTypes = GrantTypes.Code,

            // where to redirect to after login
            //emr client running at 3001
            RedirectUris = { "https://localhost:3001/signin-oidc" },

            // where to redirect to after logout
            PostLogoutRedirectUris = { "https://localhost:3001/signout-callback-oidc" },
             AllowOfflineAccess = true,
            AllowedScopes = new List<string>
            {
              IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                "emrapi"
            }
        } 
        };
    }
}