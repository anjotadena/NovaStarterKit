using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;

namespace IntegrationTests;

public static class TestSetup
{
    public static IServiceProvider BuildServiceProvider()
    {
        var services = new ServiceCollection();

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseInMemoryDatabase("TestDb_NovaStarterKit");
        });

        services.AddScoped<IRepository<User, Guid>, GenericRepository<User, Guid>>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserService, UserService>();

        return services.BuildServiceProvider();
    }
}
