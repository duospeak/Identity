using Microsoft.AspNetCore.Mvc.Filters;
using System;
using YGP.IdentityService;
using YGP.IdentityService.Configurations;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebApiMvc(this IServiceCollection services)
        {
            var builder = services.AddMvcCore(options =>
            {
                options.Filters.Add<HttpGlobalExceptionFilter>();
            });

            builder.AddJsonFormatters(options =>
            {
                options.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            });

            builder.AddApiExplorer().AddFormatterMappings();

            builder.SetCompatibilityVersion(AspNetCore.Mvc.CompatibilityVersion.Version_2_2);

            return services;
        }

        public static IServiceCollection SetupIdentityServer(this IServiceCollection services,Action<ClientOptions> optionAction)
        {
            // 使用内存存储，密钥，客户端和资源来配置身份服务器。
            // For more infomation on how to configure your identity server,visit http://www.identityserver.com.cn/Home/Detail/shiyongpingzhengbaohuapi

            var clientOptions = new ClientOptions();
            optionAction(clientOptions);

            services.AddIdentityServer(options => { options.UserInteraction.LoginUrl = "/account/login"; })
                .AddDeveloperSigningCredential(true, "tempkey.rsa")
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryClients(Config.GetClients(clientOptions))
                .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
                .AddProfileService<ProfileService>();

            return services;
        }
    }
}
