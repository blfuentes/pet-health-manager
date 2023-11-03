using application.Common.Behaviours;
using application.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace webapi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("Default");

        services.AddDbContext<ApiDbContext>(options => options.UseSqlServer(connectionString));

        services.AddDatabaseDeveloperPageExceptionFilter();

        return services;
    }

    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(application.Application).Assembly);
            config.AddOpenBehavior(typeof(TransactionBehaviour<,>));
        });

        return services;
    }
}
