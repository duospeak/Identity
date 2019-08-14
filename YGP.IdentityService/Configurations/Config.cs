using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YGP.IdentityService.Configurations;

namespace YGP.IdentityService
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            var resources = new List<ApiResource>();

            resources.Add(new ApiResource("Mall", "商城API"));
            resources.Add(new ApiResource("OrderService", "订单服务API"));

            return resources;
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("tenantId", "tenantId", new List<string>(){"tenantId"}),
                new IdentityResource("userId", "userId", new List<string>(){"userId"}),
                new IdentityResource("orgId", "orgId", new List<string>(){"orgId"}),
                new IdentityResource("userName", "userName", new List<string>(){"userName"})
            };
        }

        public static IEnumerable<Client> GetClients(ClientOptions options)
        {
            var clients = new List<Client>();

            clients.Add(new Client
            {
                AccessTokenLifetime = 3600 * 12,

                ClientId = options.Mall.ClientId,

                AllowedGrantTypes = GrantTypes.ClientCredentials,

                ClientSecrets = { new Secret(options.Mall.ClientSecrets.Sha256()) },

                AllowedScopes = { "Mall", "OrderService" }
            });

            clients.Add(new Client
            {
                AccessTokenLifetime = 3600 * 12,

                ClientId = options.Erp.ClientId,

                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                ClientSecrets = { new Secret(options.Erp.ClientSecrets.Sha256()) },

                AllowedScopes = {"OrderService" }
            });

            clients.Add(new Client
            {
                AccessTokenLifetime = 3600 * 12,

                ClientId = options.Mes.ClientId,

                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                ClientSecrets = { new Secret(options.Mes.ClientSecrets.Sha256()) },

                AllowedScopes = {"OrderService" }
            });

            clients.Add(new Client
            {
                AccessTokenLifetime = 3600 * 12,

                ClientId = options.Wms.ClientId,

                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                ClientSecrets = { new Secret(options.Wms.ClientSecrets.Sha256()) },

                AllowedScopes = {"OrderService" }
            });

            clients.Add(new Client
            {
                ClientId = "mvc",
                ClientName = "MVC Client",
                AllowedGrantTypes = GrantTypes.Implicit,

                // 登录成功回调处理地址，处理回调返回的数据
                RedirectUris = { "http://localhost:5002/signin-oidc" },

                // where to redirect to after logout
                PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "tenantId",
                    "userId",
                    "orgId",
                    "userName"
                },
                // 关闭授权页面
                RequireConsent = false                
            });

            return clients;
        }
    }
}
