using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Cqrs.Application.Abstractions.Mediator;
using Sample.Cqrs.Application.Abstractions.Repositories;
using Sample.Cqrs.Application.Abstractions.Security;
using Sample.Cqrs.Infrastructure.Mediator;
using Sample.Cqrs.Infrastructure.Persistence;
using Sample.Cqrs.Infrastructure.Repositories;
using Sample.Cqrs.Infrastructure.Security;
using System.Reflection;

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
        services.AddScoped<IPasswordHasher, PasswordHasherService>();
        services.Configure<JwtSettings>(config.GetSection("Jwt"));

        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IUserContext, UserContext>();

        //to invalidate the userʼs session
        services.AddMemoryCache();
        services.AddSingleton<ITokenBlacklist, MemoryTokenBlacklist>();

        services.AddCustomMediator(typeof(IMediator).Assembly);

        return services;
    }
}
