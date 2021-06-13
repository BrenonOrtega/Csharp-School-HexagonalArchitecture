using System;
using Microsoft.Extensions.Configuration;

namespace SchoolApp.ConsoleUI.Extensions
{
    public static class ConfigurationBuilderSetup
    {
        public static IConfigurationBuilder SetupConfig(this IConfigurationBuilder builder, string environment)
        {
            builder.SetBasePath(AppContext.BaseDirectory)
                        .AddJsonFile("appsettings.json", optional:false, reloadOnChange: true)
                        .AddJsonFile(@$"appsettings.{ environment ?? "Production" }.json", optional: true, reloadOnChange:true)
                        .AddEnvironmentVariables();          
            return builder;      
        }
    }
}