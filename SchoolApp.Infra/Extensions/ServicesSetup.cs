using System;
using Microsoft.Extensions.DependencyInjection;
using SchoolApp.Domain.Repositories.Commands;
using SchoolApp.Domain.Repositories.Queries;
using SchoolApp.Infra.Repositories.PlainFiles.Commands;
using SchoolApp.Infra.Repositories.PlainFiles.Queries;
using SchoolApp.Infra.Repositories.Postgres.Commands;
using SchoolApp.Infra.Repositories.Postgres.Queries;

namespace SchoolApp.Infra.Extensions
{
    public static class ServicesSetup
    {
        private static bool IsConfigured { get; set ;}
        public static IServiceCollection SetupPostgresRepositories(this IServiceCollection services)
        {
            ThrowIfConfigured();
            services.AddTransient<IStudentQueryRepository, PgStudentQueryRepository>()
                .AddTransient<IStudentCommandRepository, PgStudentCommandRepository>()
            ;
            IsConfigured = true;
            return services;
        }

        public static IServiceCollection SetupPlainFileRepositories (this IServiceCollection services)
        {
            ThrowIfConfigured();
            services.AddTransient<IStudentQueryRepository, PfStudentQueryRepository>()
                .AddTransient<IStudentCommandRepository, PfStudentCommandRepository>()
            ;
            IsConfigured = true;
            return services;
        }

        private static void ThrowIfConfigured() 
        {   
            if (IsConfigured) 
                throw new InvalidOperationException("Infrastructure cannot be configured more than once"); 
        }
        
    }
}