using System;
using Microsoft.Extensions.Configuration;

namespace FirstDataAccess.Extensions
{
    public static class ConfigurationBuilderSetup
    {
        public static IConfigurationBuilder BuildConfig(this IConfigurationBuilder builder)
        {
            builder.SetBasePath(AppContext.BaseDirectory)
                        .AddJsonFile("appsettings.json", optional:false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                        .AddEnvironmentVariables();
                        
            return builder;
        }
    }
}