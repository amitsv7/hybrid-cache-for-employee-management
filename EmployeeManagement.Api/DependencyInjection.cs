using EmployeeManagement.Application;
using EmployeeManagement.Domain;
using EmployeeManagement.Domain.Options;
using EmployeeManagement.Infrastructure;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace EmployeeManagement.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddAppDI(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddCoreDI(configuration)
            .AddInfrastructureDI()
            .AddApplicationDI();
       
        
        services.AddStackExchangeRedisCache(options =>
        {
            var redisConnectionStringOptions = services.BuildServiceProvider()
                .GetRequiredService<IOptions<ConnectionStringOptions>>().Value;
            options.Configuration = redisConnectionStringOptions.RedisCacheConnectionStrings;
        });
        
        services.AddOptions<BasicAuthenticationOptions>().BindConfiguration(BasicAuthenticationOptions.SectionName);

        return services;
    }
}