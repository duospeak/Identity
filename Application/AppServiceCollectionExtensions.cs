using Infrastructure;
using MediatR;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AppServiceCollectionExtensions
    {
        public static IServiceCollection AddApp(this IServiceCollection services,
            Action<InfrastructureOptions> optionAction)
        {
            // auto discovery command handlers
            services.AddMediatR();

            services.AddInfrastructure(optionAction);

            return services;
        }
    }
}
