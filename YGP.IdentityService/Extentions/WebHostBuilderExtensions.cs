using Serilog;
using YGP.IdentityService.Configurations;

namespace Microsoft.AspNetCore.Hosting
{
    internal static class WebHostBuilderExtensions
    {
        public static IWebHostBuilder UseElkLogger(this IWebHostBuilder builder)
        {
            builder.ConfigureLogging((context, logger) =>
            {
                var logstashUri = context.Configuration[AppDefaults.LogstashUri];

                if (logstashUri == null)
                {
                    return;
                }

                var serilogger = new LoggerConfiguration().WithElkLogger(options =>
                {
                    options.LogstashUri = logstashUri;
                    options.ServiceName = context.GetLoggerIndexName();
                    options.Envrionment = context.GetLoggerEnvironment();
                }).CreateLogger();

                logger.AddSerilog(serilogger);
            });

            return builder;
        }

        private static string GetLoggerIndexName(this WebHostBuilderContext context)
        {
            return context.HostingEnvironment.ApplicationName.Replace(".", "-");
        }

        private static string GetLoggerEnvironment(this WebHostBuilderContext context)
        {
            if (context.HostingEnvironment.IsEnvironment("TEST"))
            {
                return "test";
            }

            if (context.HostingEnvironment.IsDevelopment())
            {
                return "dev";
            }

            if (context.HostingEnvironment.IsStaging())
            {
                return "pre";
            }

            if (context.HostingEnvironment.IsProduction())
            {
                return "prod";
            }

            return context.HostingEnvironment.EnvironmentName;
        }
    }
}
