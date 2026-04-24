using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Authentication.Ports.Service;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Clasifications.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Features.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Permissions.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Configurations;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.ApiKeys;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Clasifications;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.FeatureKinds;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Features;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.InterestAreas;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Macroprograms;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Objectives;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Permissions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.PublicPolicies;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Roles;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.UnitMeasurements;
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

        services.AddScoped<IUnitMeasurementQueryRepositoryPort, UnitMeasurementQueryRepositoryPortAdapter>();
        services.AddScoped<IUnitMeasurementCommandRepositoryPort, UnitMeasurementCommandRepositoryPortAdapter>();

        services.AddScoped<IInterestAreaQueryRepositoryPort, InterestAreaQueryRepositoryPortAdapter>();
        services.AddScoped<IInterestAreaCommandRepositoryPort, InterestAreaCommandRepositoryPortAdapter>();

        services.AddScoped<IMacroprogramQueryRepositoryPort, MacroprogramQueryRepositoryPortAdapter>();
        services.AddScoped<IMacroprogramCommandRepositoryPort, MacroprogramCommandRepositoryPortAdapter>();

        services.AddScoped<IPublicPolicyQueryRepositoryPort, PublicPolicyQueryRepositoryPortAdapter>();
        services.AddScoped<IPublicPolicyCommandRepositoryPort, PublicPolicyCommandRepositoryPortAdapter>();

        services.AddScoped<IObjectiveQueryRepositoryPort, ObjectiveQueryRepositoryPortAdapter>();
        services.AddScoped<IObjectiveCommandRepositoryPort, ObjectiveCommandRepositoryPortAdapter>();

        services.AddScoped<IPersonQueryRepositoryPort, PersonQueryRepositoryPortAdapter>();
        services.AddScoped<IPersonCommandRepositoryPort, PersonCommandRepositoryPortAdapter>();

        services.AddScoped<IOrganizationKindQueryRepositoryPort, OrganizationKindQueryRepositoryPortAdapter>();
        services.AddScoped<IOrganizationKindCommandRepositoryPort, OrganizationKindCommandRepositoryPortAdapter>();

        services.AddScoped<IOrganizationQueryRepositoryPort, OrganizationQueryRepositoryPortAdapter>();
        services.AddScoped<IOrganizationCommandRepositoryPort, OrganizationCommandRepositoryPortAdapter>();

        services.AddScoped<ITerritorialBarrierQueryRepositoryPort, TerritorialBarrierQueryRepositoryPortAdapter>();
        services.AddScoped<ITerritorialBarrierCommandRepositoryPort, TerritorialBarrierCommandRepositoryPortAdapter>();

        services.AddScoped<ITerritoryPotentialQueryRepositoryPort, TerritoryPotentialQueryRepositoryPortAdapter>();
        services.AddScoped<ITerritoryPotentialCommandRepositoryPort, TerritoryPotentialCommandRepositoryPortAdapter>();

        services.AddScoped<IClasificationQueryRepositoryPort, ClasificationQueryRepositoryPortAdapter>();
        services.AddScoped<IClasificationCommandRepositoryPort, ClasificationCommandRepositoryPortAdapter>();

        services.AddScoped<IKeyVariableQueryRepositoryPort, KeyVariableQueryRepositoryPortAdapter>();
        services.AddScoped<IKeyVariableCommandRepositoryPort, KeyVariableCommandRepositoryPortAdapter>();

        services.AddScoped<IFeatureKindQueryRepositoryPort, FeatureKindQueryRepositoryPortAdapter>();
        services.AddScoped<IFeatureKindCommandRepositoryPort, FeatureKindCommandRepositoryPortAdapter>();

        services.AddScoped<IFeatureQueryRepositoryPort, FeatureQueryRepositoryPortAdapter>();
        services.AddScoped<IFeatureCommandRepositoryPort, FeatureCommandRepositoryPortAdapter>();

        services.AddScoped<IIdentityAuthenticationServicePort, LocalIdentityAuthenticationServicePortAdapter>();

        services.AddSingleton<IDataIntegrityServicePort, LocalDataIntegrityServicePortAdapter>();
        services.AddSingleton<IStringHashingServicePort, SHA256StringHashingServicePortAdapter>();

        return services;
    }
}