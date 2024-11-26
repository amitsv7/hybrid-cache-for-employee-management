using Microsoft.Extensions.Configuration;
using EmployeeManagement.Domain.Options;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddCoreDI(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ConnectionStringOptions>(configuration.GetSection(ConnectionStringOptions.SectionName));

        return services;
    }
    
}