using Domain.SeedWork;
using Infrastructure;
using Infrastructure.DbContexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
    Action<InfrastructureOptions> optionAction)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (optionAction == null)
            {
                throw new ArgumentNullException(nameof(optionAction));
            }

            services.Configure(optionAction);

            services.AddDbContext<UserContext>((sp, options) =>
            {
                var value = sp.GetRequiredService<IOptions<InfrastructureOptions>>();

                options.UseMySql(value.Value.MySqlConnectionString, mysql =>
                {
                    mysql.MigrationsAssembly("YGP.IdentityService");
                });
            });

            services.TryAddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
