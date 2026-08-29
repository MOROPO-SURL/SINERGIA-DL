using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeyTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Authentication.Ports.Service;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ClassificationTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Documents.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivities.Ports;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivityTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKindTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Features.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Images.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreaTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariableTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Locations.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.MacroprogramTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ObjectiveTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OperationReports.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKindTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.Ports;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Permissions.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PersonTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicyTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Roles.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.RoleTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialResponsabilityActions.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemandTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxeTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLineTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProgramTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeas.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeaTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarrierTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentialTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurementTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UserTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Configurations;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Interceptors;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.ApiKeys;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.ApiKeyTraces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.Classifications;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.ClassificationTraces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.DevelopmentActorProfiles;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.Documents;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.EconomicActivities;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.EconomicActivityTraces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.FeatureKinds;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.FeatureKindTraces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.Features;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.FeatureTraces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.Images;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.InterestAreas;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.InterestAreaTraces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.KeyVariables;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.KeyVariableTraces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.Locations;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.Macroprograms;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.MacroprogramTraces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.Objectives;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.ObjectiveTraces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.OperationReports;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.OrganizationKinds;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.OrganizationKindTraces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.Organizations;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.OrganizationTraces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.PDLModalities;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.Permissions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.Persons;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.PersonTraces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.PublicPolicies;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.PublicPolicyTraces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.Roles;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.RoleTraces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.SocialResponsabilityActions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.SocialSupportDemands;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.SocialSupportDemandTraces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.StrategicAxes;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.StrategicAxeTraces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.StrategicLines;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.StrategicLineTraces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.StrategicPrograms;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.StrategicProgramTraces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.StrategicProjectIdeas;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.StrategicProjectIdeaTraces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.StrategicProjectKinds;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.StrategicProjects;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.StrategicProjectTraces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.TerritorialBarriers;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.TerritorialBarrierTraces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.TerritoryPotentials;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.TerritoryPotentialTraces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.UnitMeasurements;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.UnitMeasurementTraces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.Users;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.UserTraces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Service;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Service.Authentication;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection UseInfrastructureLayer(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.Configure<AuthenticationConfiguration>(configuration.GetSection("Authentication"));

        services.AddDbContext<DefaultDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IPermissionQueryRepositoryPort, PermissionQueryRepositoryPortAdapter>();

        services.AddScoped<IImageCommandRepositoryPort, ImageCommandRepositoryPortAdapter>();

        services.AddScoped<IDocumentCommandRepositoryPort, DocumentCommandRepositoryPortAdapter>();

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
        services.AddScoped<IStrategicProjectIndicatorChangeQueryRepositoryPort, StrategicProjectIndicatorChangeQueryRepositoryPortAdapter>();

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
        services.AddScoped<IStrategicAxeTraceQueryRepositoryPort, StrategicAxeTraceQueryRepositoryPortAdapter>();
        services.AddScoped<IPublicPolicyTraceQueryRepositoryPort, PublicPolicyTraceQueryRepositoryPortAdapter>();
        services.AddScoped<ITerritorialBarrierTraceQueryRepositoryPort, TerritorialBarrierTraceQueryRepositoryPortAdapter>();
        services.AddScoped<ITerritoryPotentialTraceQueryRepositoryPort, TerritoryPotentialTraceQueryRepositoryPortAdapter>();
        services.AddScoped<IStrategicProgramTraceQueryRepositoryPort, StrategicProgramTraceQueryRepositoryPortAdapter>();
        services.AddScoped<IStrategicProjectTraceQueryRepositoryPort, StrategicProjectTraceQueryRepositoryPortAdapter>();
        services.AddScoped<IStrategicProjectIdeaTraceQueryRepositoryPort, StrategicProjectIdeaTraceQueryRepositoryPortAdapter>();
        services.AddScoped<IUnitMeasurementTraceQueryRepositoryPort, UnitMeasurementTraceQueryRepositoryPortAdapter>();
        services.AddScoped<ISocialSupportDemandTraceQueryRepositoryPort, SocialSupportDemandTraceQueryRepositoryPortAdapter>();
        services.AddScoped<IEconomicActivityTraceQueryRepositoryPort, EconomicActivityTraceQueryRepositoryPortAdapter>();

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
        services.AddScoped<ISaveChangesInterceptor, StrategicAxeChangeDomainTracingInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, PublicPolicyChangeDomainTracingInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, TerritorialBarrierChangeDomainTracingInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, TerritoryPotentialChangeDomainTracingInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, StrategicProgramChangeDomainTracingInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, StrategicProjectChangeDomainTracingInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, StrategicProjectIdeaChangeDomainTracingInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, UnitMeasurementChangeDomainTracingInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, SocialSupportDemandChangeDomainTracingInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, EconomicActivityChangeDomainTracingInterceptor>();

        return services;
    }
}