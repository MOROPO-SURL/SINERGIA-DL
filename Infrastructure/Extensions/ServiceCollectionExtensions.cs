using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeyTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Authentication.Ports.Service;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Classifications.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ClassificationTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.Ports;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKindTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Features.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Images.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreaTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariables.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariableTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Locations.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.MacroprogramTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ObjectiveTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKindTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PDLModalities.Ports;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Permissions.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PersonTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.RoleTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLineTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeas.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UserTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Configurations;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Interceptors;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.ApiKeys;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.ApiKeyTraces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Classifications;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.ClassificationTraces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.DevelopmentActorProfiles;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.EconomicActivities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.FeatureKinds;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.FeatureKindTraces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Features;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.FeatureTraces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Images;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.InterestAreas;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.InterestAreaTraces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.KeyVariables;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.KeyVariableTraces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Locations;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Macroprograms;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.MacroprogramTraces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Objectives;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.ObjectiveTraces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.OperationReports;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.OrganizationKinds;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.OrganizationKindTraces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Organizations;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.OrganizationTraces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.PDLModalities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Permissions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Persons;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.PersonTraces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.PublicPolicies;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Roles;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.RoleTraces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.SocialResponsabilityActions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.SocialSupportDemands;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.StrategicAxes;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.StrategicLines;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.StrategicLineTraces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.StrategicPrograms;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.StrategicProjectIdeas;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.StrategicProjectKinds;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.StrategicProjects;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.TerritorialBarriers;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.TerritoryPotentials;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.UnitMeasurements;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Users;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.UserTraces;
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

        services.AddScoped<IImageCommandRepositoryPort, ImageCommandRepositoryPortAdapter>();

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
        services.AddScoped<IObjectiveActionIndicatorChangeQueryRepositoryPort, ObjectiveActionIndicatorChangeQueryRepositoryPortAdapter>();

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

        services.AddScoped<IClassificationQueryRepositoryPort, ClassificationQueryRepositoryPortAdapter>();
        services.AddScoped<IClassificationCommandRepositoryPort, ClassificationCommandRepositoryPortAdapter>();

        services.AddScoped<IKeyVariableQueryRepositoryPort, KeyVariableQueryRepositoryPortAdapter>();
        services.AddScoped<IKeyVariableCommandRepositoryPort, KeyVariableCommandRepositoryPortAdapter>();

        services.AddScoped<IFeatureKindQueryRepositoryPort, FeatureKindQueryRepositoryPortAdapter>();
        services.AddScoped<IFeatureKindCommandRepositoryPort, FeatureKindCommandRepositoryPortAdapter>();

        services.AddScoped<IFeatureQueryRepositoryPort, FeatureQueryRepositoryPortAdapter>();
        services.AddScoped<IFeatureCommandRepositoryPort, FeatureCommandRepositoryPortAdapter>();

        services.AddScoped<IStrategicAxeQueryRepositoryPort, StrategicAxeQueryRepositoryPortAdapter>();
        services.AddScoped<IStrategicAxeCommandRepositoryPort, StrategicAxeCommandRepositoryPortAdapter>();

        services.AddScoped<IStrategicLineQueryRepositoryPort, StrategicLineQueryRepositoryPortAdapter>();
        services.AddScoped<IStrategicLineCommandRepositoryPort, StrategicLineCommandRepositoryPortAdapter>();

        services.AddScoped<IStrategicProgramQueryRepositoryPort, StrategicProgramQueryRepositoryPortAdapter>();
        services.AddScoped<IStrategicProgramCommandRepositoryPort, StrategicProgramCommandRepositoryPortAdapter>();
        services.AddScoped<IStrategicProgramActionIndicatorChangeQueryRepositoryPort, StrategicProgramActionIndicatorChangeQueryRepositoryPortAdapter>();

        services.AddScoped<IStrategicProjectKindQueryRepositoryPort, StrategicProjectKindQueryRepositoryPortAdapter>();
        services.AddScoped<IStrategicProjectKindCommandRepositoryPort, StrategicProjectKindCommandRepositoryPortAdapter>();

        services.AddScoped<IStrategicProjectQueryRepositoryPort, StrategicProjectQueryRepositoryPortAdapter>();
        services.AddScoped<IStrategicProjectCommandRepositoryPort, StrategicProjectCommandRepositoryPortAdapter>();

        services.AddScoped<IStrategicProjectIdeaQueryRepositoryPort, StrategicProjectIdeaQueryRepositoryPortAdapter>();
        services.AddScoped<IStrategicProjectIdeaCommandRepositoryPort, StrategicProjectIdeaCommandRepositoryPortAdapter>();

        services.AddScoped<IEconomicActivityQueryRepositoryPort, EconomicActivityQueryRepositoryPortAdapter>();
        services.AddScoped<IEconomicActivityCommandRepositoryPort, EconomicActivityCommandRepositoryPortAdapter>();

        services.AddScoped<IPDLModalityQueryRepositoryPort, PDLModalityQueryRepositoryPortAdapter>();
        services.AddScoped<IPDLModalityCommandRepositoryPort, PDLModalityCommandRepositoryPortAdapter>();

        services.AddScoped<ISRLDevelopmentActorProfileQueryRepositoryPort, SRLDevelopmentActorProfileQueryRepositoryPortAdapter>();
        services.AddScoped<ISRLDevelopmentActorProfileCommandRepositoryPort, SRLDevelopmentActorProfileCommandRepositoryPortAdapter>();
        services.AddScoped<INaturalOwnedPDLDevelopmentActorProfileQueryRepositoryPort, NaturalOwnedPDLDevelopmentActorProfileQueryRepositoryPortAdapter>();
        services.AddScoped<INaturalOwnedPDLDevelopmentActorProfileCommandRepositoryPort, NaturalOwnedPDLDevelopmentActorProfileCommandRepositoryPortAdapter>();
        services.AddScoped<ILegalOwnedPDLDevelopmentActorProfileQueryRepositoryPort, LegalOwnedPDLDevelopmentActorProfileQueryRepositoryPortAdapter>();
        services.AddScoped<ILegalOwnedPDLDevelopmentActorProfileCommandRepositoryPort, LegalOwnedPDLDevelopmentActorProfileCommandRepositoryPortAdapter>();

        services.AddScoped<ISRLOperationReportQueryRepositoryPort, SRLOperationReportQueryRepositoryPortAdapter>();
        services.AddScoped<ISRLOperationReportCommandRepositoryPort, SRLOperationReportCommandRepositoryPortAdapter>();
        services.AddScoped<IPDLOperationReportQueryRepositoryPort, PDLOperationReportQueryRepositoryPortAdapter>();
        services.AddScoped<IPDLOperationReportCommandRepositoryPort, PDLOperationReportCommandRepositoryPortAdapter>();

        services.AddScoped<ISRLSocialResponsabilityActionQueryRepositoryPort, SRLSocialResponsabilityActionQueryRepositoryPortAdapter>();
        services.AddScoped<ISRLSocialResponsabilityActionCommandRepositoryPort, SRLSocialResponsabilityActionCommandRepositoryPortAdapter>();
        services.AddScoped<IPDLSocialResponsabilityActionQueryRepositoryPort, PDLSocialResponsabilityActionQueryRepositoryPortAdapter>();
        services.AddScoped<IPDLSocialResponsabilityActionCommandRepositoryPort, PDLSocialResponsabilityActionCommandRepositoryPortAdapter>();

        services.AddScoped<ILocationQueryRepositoryPort, LocationQueryRepositoryPortAdapter>();
        services.AddScoped<ILocationCommandRepository, LocationCommandRepositoryPortAdapter>();

        services.AddScoped<ISocialSupportDemandQueryRepositoryPort, SocialSupportDemandQueryRepositoryPortAdapter>();
        services.AddScoped<ISocialSupportDemandCommandRepositoryPort, SocialSupportDemandCommandRepositoryPortAdapter>();

        services.AddScoped<IUserTraceQueryRepositoryPort, UserTraceQueryRepositoryPortAdapter>();
        services.AddScoped<IRoleTraceQueryRepositoryPort, RoleTraceQueryRepositoryPortAdapter>();
        services.AddScoped<IPersonTraceQueryRepositoryPort, PersonTraceQueryRepositoryPortAdapter>();
        services.AddScoped<IOrganizationTraceQueryRepositoryPort, OrganizationTraceQueryRepositoryPortAdapter>();
        services.AddScoped<IApiKeyTraceQueryRepositoryPort, ApiKeyTraceQueryRepositoryPortAdapter>();
        services.AddScoped<IClassificationTraceQueryRepositoryPort, ClassificationTraceQueryRepositoryPortAdapter>();
        services.AddScoped<IFeatureKindTraceQueryRepositoryPort, FeatureKindTraceQueryRepositoryPortAdapter>();
        services.AddScoped<IStrategicLineTraceQueryRepositoryPort, StrategicLineTraceQueryRepositoryPortAdapter>();
        services.AddScoped<IFeatureTraceQueryRepositoryPort, FeatureTraceQueryRepositoryPortAdapter>();
        services.AddScoped<IInterestAreaTraceQueryRepositoryPort, InterestAreaTraceQueryRepositoryPortAdapter>();
        services.AddScoped<IKeyVariableTraceQueryRepositoryPort, KeyVariableTraceQueryRepositoryPortAdapter>();
        services.AddScoped<IMacroprogramTraceQueryRepositoryPort, MacroprogramTraceQueryRepositoryPortAdapter>();
        services.AddScoped<IObjectiveTraceQueryRepositoryPort, ObjectiveTraceQueryRepositoryPortAdapter>();
        services.AddScoped<IOrganizationKindTraceQueryRepositoryPort, OrganizationKindTraceQueryRepositoryPortAdapter>();

        services.AddScoped<IIdentityAuthenticationServicePort, LocalIdentityAuthenticationServicePortAdapter>();

        services.AddSingleton<IDataIntegrityServicePort, LocalDataIntegrityServicePortAdapter>();
        services.AddSingleton<IStringHashingServicePort, SHA256StringHashingServicePortAdapter>();
        services.AddSingleton<IFileStoreServicePort, RelativePathLocalFileServicePortAdapter>();

        services.AddScoped<ISaveChangesInterceptor, UserChangeDomainTracingInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, RoleChangeDomainTracingInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, PersonChangeDomainTracingInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, OrganizationChangeDomainTracingInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, StrategicLineChangeDomainTracingInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, FeatureChangeDomainTracingInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, InterestAreaChangeDomainTracingInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, KeyVariableChangeDomainTracingInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, MacroprogramChangeDomainTracingInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, ObjectiveChangeDomainTracingInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, OrganizationKindChangeDomainTracingInterceptor>();

        return services;
    }
}