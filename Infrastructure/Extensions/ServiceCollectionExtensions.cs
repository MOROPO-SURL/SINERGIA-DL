using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Authentication.Ports.Service;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Permissions.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Configurations;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.ApiKeys;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Objectives;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Permissions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Roles;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Users;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Service;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Service.Authentication;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection UseInfrastructureLayer(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.Configure<AuthenticationConfiguration>(configuration.GetSection("Authentication"));

        services.AddDbContext<DefaultDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IPermissionQueryRepositoryPort, PermissionQueryRepositoryPortAdapter>();

        services.AddScoped<IRoleQueryRepositoryPort, RoleQueryRepositoryPortAdapter>();
        services.AddScoped<IRoleCommandRepositoryPort, RoleCommandRepositoryPortAdapter>();
        services.AddScoped<IRolePermissionBridgeCommandRepositoryPort, RolePermissionBridgeCommandRepositoryPortAdapter>();

        services.AddScoped<IApiKeyQueryRepositoryPort, ApiKeyQueryRepositoryPortAdapter>();
        services.AddScoped<IApiKeyCommandRepositoryPort, ApiKeyCommandRepositoryPortAdapter>();
        services.AddScoped<IApiKeyPermissionBridgeCommandRepositoryPort, ApiKeyPermissionBridgeCommandRepositoryPortAdapter>();

        services.AddScoped<IUserQueryRepositoryPort, UserQueryRepositoryPortAdapter>();
        services.AddScoped<IUserCommandRepositoryPort, UserCommandRepositoryPortAdapter>();
        services.AddScoped<IUserRoleBridgeCommandRepositoryPort, UserRoleBridgeCommandRepositoryPortAdapter>();

        services.AddScoped<IObjectiveQueryRepositoryPort, ObjectiveQueryRepositoryPortAdapter>();
        services.AddScoped<IObjectiveCommandRepositoryPort, ObjectiveCommandRepositoryPortAdapter>();

        services.AddScoped<IIdentityAuthenticationServicePort, LocalIdentityAuthenticationServicePortAdapter>();

        services.AddSingleton<IDataIntegrityServicePort, LocalDataIntegrityServicePortAdapter>();
        services.AddSingleton<IStringHashingServicePort, SHA256StringHashingServicePortAdapter>();

        return services;
    }
}