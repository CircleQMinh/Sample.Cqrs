using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Cqrs.Application.Abstractions;
using Sample.Cqrs.Infrastructure.Persistence;
using Sample.Cqrs.Infrastructure.Repositories;

namespace Sample.Cqrs.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
       this IServiceCollection services,
       IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(
                config.GetConnectionString("sqlConnection")));


        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        return services;
    }
}
