using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MOROPO.GEDET.CAM.Core.Common.Ports.Service;
using MOROPO.GEDET.CAM.Core.UseCases.Authentication.Ports.Service;
using MOROPO.GEDET.CAM.Core.UseCases.Permissions.Ports.Repository;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.Ports.Repository;
using MOROPO.GEDET.CAM.Core.UseCases.Users.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Common.Ports.Service;
using MOROPO.GEDET.CAM.Infrastructure.Configurations;
using MOROPO.GEDET.CAM.Infrastructure.Ports.Adapters.Repository.Permissions;
using MOROPO.GEDET.CAM.Infrastructure.Ports.Adapters.Repository.Roles;
using MOROPO.GEDET.CAM.Infrastructure.Ports.Adapters.Repository.Users;
using MOROPO.GEDET.CAM.Infrastructure.Ports.Adapters.Service;
using MOROPO.GEDET.CAM.Infrastructure.Ports.Adapters.Service.Authentication;

namespace MOROPO.GEDET.CAM.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection UseInfrastructureLayer(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.Configure<AuthenticationConfiguration>(configuration.GetSection("Authentication"));

        services.AddDbContext<Persistence.EF.DefaultDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IPermissionQueryRepositoryPort, PermissionQueryRepositoryPortAdapter>();

        services.AddScoped<IRoleQueryRepositoryPort, RoleQueryRepositoryPortAdapter>();
        services.AddScoped<IRoleCommandRepositoryPort, RoleCommandRepositoryPortAdapter>();
        services.AddScoped<IRolePermissionBridgeCommandRepositoryPort, RolePermissionBridgeCommandRepositoryPortAdapter>();

        services.AddScoped<IUserQueryRepositoryPort, UserQueryRepositoryPortAdapter>();
        services.AddScoped<IUserCommandRepositoryPort, UserCommandRepositoryPortAdapter>();
        services.AddScoped<IUserRoleBridgeCommandRepositoryPort, UserRoleBridgeCommandRepositoryPortAdapter>();

        services.AddScoped<IIdentityAuthenticationServicePort, LocalIdentityAuthenticationServicePortAdapter>();

        services.AddSingleton<IDataIntegrityServicePort, LocalDataIntegrityServicePortAdapter>();
        services.AddSingleton<IStringHashingServicePort, SHA256StringHashingServicePortAdapter>();

        return services;
    }
}