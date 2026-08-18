using Mapster;
using Microsoft.Extensions.DependencyInjection;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeyTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ClassificationTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Documents.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKindTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Features.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Images.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreaTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariables.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariableTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.MacroprogramTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ObjectiveTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKindTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PDLModalities.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Permissions.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PersonTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicyTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.RoleTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxeTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLineTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeas.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarrierTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentialTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UserTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritorialBarrierAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Extensions;

public static class ServiceProviderExtensions
{
    public static void ApplyCoreMappings(this IServiceProvider provider)
    {
        IStringHashingServicePort stringHashingService = provider.GetService<IStringHashingServicePort>()!;

        TypeAdapterConfig.GlobalSettings.Apply(
            new UserDetailDtoMappingRegister(),
            new UserBasicDtoMappingRegister(provider.GetRequiredService<IDataIntegrityServicePort>()),
            new UserDetailQueryMappingRegister(),
            new UserCreateCommandMappingRegister(stringHashingService),
            new UserUpdateCommandMappingRegister(),
            new PasswordUserUpdateCommandMappingRegister(stringHashingService),
            new UserCreateCommandMappingRegister(stringHashingService),
            new PrimitivesUserMappingRegister(),

            new RoleBasicDtoMappingRegister(),
            new RoleDetailDtoMappingRegister(),
            new RoleCreateCommandMappingRegister(),

            new ApiKeyBasicDtoMappingRegister(),
            new ApiKeyDetailDtoMappingRegister(),
            new ApiKeyDetailQueryMappingRegister(),
            new ApiKeyCreateCommandMappingRegister(stringHashingService),
            new ApiKeyUpdateCommandMappingRegister(),
            new PrimitivesApiKeyMappingRegister(),

            new ObjectiveEntityMappingRegister(),

            new PermissionDetailDtoMappingRegister(),

            new PrimitivesUnitMeasurementMappingRegister(),
            new UnitMeasurementBasicDtoMappingRegister(),
            new UnitMeasurementCreateCommandMappingRegister(),
            new UnitMeasurementDetailDtoMappingRegister(),
            new UnitMeasurementDetailQueryMappingRegister(),
            new UnitMeasurementUpdateCommandMappingRegister(),

            new PrimitivesInterestAreaMappingRegister(),
            new InterestAreaBasicDtoMappingRegister(),
            new InterestAreaCreateCommandMappingRegister(),
            new InterestAreaDetailDtoMappingRegister(),
            new InterestAreaDetailQueryMappingRegister(),
            new InterestAreaUpdateCommandMappingRegister(),

            new PrimitivesMacroprogramMappingRegister(),
            new MacroprogramBasicDtoMappingRegister(),
            new MacroprogramCreateCommandMappingRegister(),
            new MacroprogramDetailDtoMappingRegister(),
            new MacroprogramDetailQueryMappingRegister(),
            new MacroprogramUpdateCommandMappingRegister(),

            new PrimitivesPublicPolicyMappingRegister(),
            new PublicPolicyBasicDtoMappingRegister(),
            new PublicPolicyCreateCommandMappingRegister(),
            new PublicPolicyDetailDtoMappingRegister(),
            new PublicPolicyDetailQueryMappingRegister(),
            new PublicPolicyUpdateCommandMappingRegister(),

            new ImageEntityMappingRegister(),

            new DocumentEntityMappingRegister(),

            new PersonEntityMappingRegister(),

            new OrganizationKindEntityMappingRegister(),

            new OrganizationEntityMappingRegister(),

            new TerritorialBarrierEntityMappingRegister(),

            new TerritoryPotentialEntityMappingRegister(),

            new KeyVariableEntityMappingRegister(),

            new FeatureKindEntityMappingRegister(),

            new FeatureEntityMappingRegister(),

            new StrategicAxeEntityMappingRegister(),

            new StrategicLineEntityMappingRegister(),

            new StrategicProgramEntityMappingRegister(),

            new LocationMappingRegister(),

            new SocialSupportDemandMappingRegister(),

            new SocialResponsabilityActionMappingRegister(),

            new StrategicProjectIdeaEntityMappingRegister(),

            new UserTraceEntityMappingRegister(),

            new RoleTraceEntityMappingRegister(),

            new PersonTraceEntityMappingRegister(),

            new StrategicProjectKindEntityMappingRegister(),

            new StrategicProjectEntityMappingRegister(),

            new OrganizationTraceEntityMappingRegister(),

            new ApiKeyTraceEntityMappingRegister(),

            new ClassificationTraceEntityMappingRegister(),

            new FeatureKindTraceEntityMappingRegister(),

            new StrategicLineTraceEntityMappingRegister(),

            new FeatureTraceEntityMappingRegister(),

            new InterestAreaTraceEntityMappingRegister(),

            new KeyVariableTraceEntityMappingRegister(),

            new EconomicActivityEntityMappingRegister(),

            new PDLModalityEntityMappingRegister(),

            new DevelopmentActorProfileMappingRegister(),

            new OperationReportMappingRegister(),

            new KeyVariableTraceEntityMappingRegister(),

            new MacroprogramTraceEntityMappingRegister(),

            new ObjectiveTraceEntityMappingRegister(),

            new OrganizationKindTraceEntityMappingRegister(),

            new StrategicAxeTraceEntityMappingRegister(),

            new PublicPolicyTraceEntityMappingRegister(),

            new TerritorialBarrierTraceEntityMappingRegister(),

            new TerritoryPotentialTraceEntityMappingRegister()
        );
    }
}
