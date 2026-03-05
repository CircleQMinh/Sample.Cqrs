using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Cqrs.Application.Abstractions.Repositories;
using Sample.Cqrs.Application.Abstractions.Security;
using Sample.Cqrs.Infrastructure.Persistence;
using Sample.Cqrs.Infrastructure.Repositories;
using Sample.Cqrs.Infrastructure.Security;


namespace Sample.Cqrs.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
       this IServiceCollection services,
       IConfiguration config)
    {
        //services.AddDbContext<AppDbContext>(opt =>
        //    opt.UseSqlServer(
        //        config.GetConnectionString("sqlConnection")));
        services.AddDbContext<AppDbContext>(opt =>
            opt.UseInMemoryDatabase("TestDb"));


        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IPasswordHasher, PasswordHasherService>();
        services.Configure<JwtSettings>(config.GetSection("Jwt"));

        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IUserContext, UserContext>();

        //to invalidate the userʼs session
        services.AddMemoryCache();
        services.AddSingleton<ITokenBlacklist, MemoryTokenBlacklist>();

        return services;
    }
}
