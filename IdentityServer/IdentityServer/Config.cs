// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                 new ApiResource("api1", "My API")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                 new Client
                {
                    ClientId = "client",

                    // 没有交互式用户，请使用clientid / secret进行身份验证
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // 认证加密
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // 客户有权访问的范围
                    AllowedScopes = { "api1" }
                }
            };
    }
}