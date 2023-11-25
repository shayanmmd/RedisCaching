using Application;
using Application_Contracts;
using Domain;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServicesConfigs
{
    public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddTransient<IPersonApplication, PersonApplication>();
        services.AddTransient<IPersonRepository, PersonRepository>();
        RedisCache.GetInstance();  
        
        services.AddDbContext<MainDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        return services;
    }
}
