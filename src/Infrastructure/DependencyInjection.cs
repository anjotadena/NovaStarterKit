﻿using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Auth;
using Infrastructure.Logging;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped(typeof(IAppLogger<>), typeof(SerilogAdapter<>));

        // Generic fallback for all entities  
        services.AddScoped(typeof(IRepository<,>), typeof(GenericRepository<,>));

        // Specific override for each entities  
        services.AddScoped<IRepository<User, Guid>, UserRepository>();
        services.AddScoped<IRepository<Role, Guid>, RoleRepository>();
        services.AddScoped<IRepository<Permission, Guid>, PermissionRepository>();

        // Unit of work  
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>(); // Fully qualify the type to avoid namespace conflict

        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        return services;
    }
}
