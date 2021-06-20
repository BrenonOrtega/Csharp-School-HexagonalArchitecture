using System;
using Microsoft.Extensions.DependencyInjection;
using SchoolApp.Domain.Repositories.Commands;
using SchoolApp.Domain.Repositories.Queries;
using SchoolApp.Infra.Repositories.JsonFiles.Commands;
using SchoolApp.Infra.Repositories.JsonFiles.Queries;
using SchoolApp.Infra.Repositories.Postgres.Commands;
using SchoolApp.Infra.Repositories.Postgres.Queries;
using SchoolApp.Infra.Repositories.Redis;
using SchoolApp.Services.Repositories.Async;

namespace SchoolApp.Infra.Extensions
{
    public static class ServicesSetup
    {
        private static bool IsConfigured { get; set ;}
        public static IServiceCollection SetupPostgresRepositories(this IServiceCollection services)
        {
            ThrowIfConfigured();
            services.AddScoped<IStudentQueryRepository, PgStudentQueryRepository>()
                .AddScoped<IStudentCommandRepository, PgStudentCommandRepository>()
                .AddScoped<ICourseQueryRepository, PgCourseQueryRepository>()
            ;
            IsConfigured = true;
            return services;
        }

        public static IServiceCollection SetupJsonFilesRepositories (this IServiceCollection services)
        {
            ThrowIfConfigured();
            services.AddScoped<IStudentQueryRepository, JsonStudentQueryRepository>()
                .AddScoped<IStudentCommandRepository, JsonStudentCommandRepository>()
                .AddScoped<ICourseQueryRepository, JsonCourseQueryRepository>()
                .AddScoped<ICourseCommandRepository, JsonCourseCommandRepository>()
            ;
            IsConfigured = true;
            return services;
        }

        public static IServiceCollection SetupRedis(this IServiceCollection services)
        {
            ThrowIfConfigured();
            services.AddScoped<IStudentCommandRepository, RedisStudentRepository>()
                .AddScoped<IStudentQueryRepository, RedisStudentRepository>()
                .AddScoped<RedisStudentRepository>();   
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