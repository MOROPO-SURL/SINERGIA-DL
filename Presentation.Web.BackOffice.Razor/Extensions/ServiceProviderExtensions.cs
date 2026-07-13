using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.ApiKeys.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.ApiKeyTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Authentication.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Classifications.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.ClassificationTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.FeatureKinds.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.FeatureKindTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Features.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.FeatureTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.InterestAreas.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.InterestAreaTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.KeyVariables.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.KeyVariableTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Macroprograms.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.MacroprogramTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Objectives.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.ObjectiveTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.OrganizationKinds.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Organizations.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.OrganizationTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Persons.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.PersonTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.PublicPolicies.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Roles.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.RoleTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Session.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.StrategicAxes.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.StrategicLineTraces.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.StrategicPrograms.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.StrategicProjectKinds.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.StrategicProjects.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.TerritorialBarriers.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.TerritoryPotentials.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.UnitMeasurements.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Users.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.UserTraces.Mappings;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Extensions;

internal static class ServiceProviderExtensions
{
    public static void ApplyPresentationMappings(this IServiceProvider self)
    {
        TypeAdapterConfig.GlobalSettings.Apply(
            new AuthenticateRequestModelMappingRegister(),

            new UserCreateViewModelMappingRegister(),
            new UserUpdateViewModelMappingRegister(),
            new UserChangePasswordViewModelMappingRegister(),
            new PrimitiveUserMappingRegister(),

            new RoleCreateViewModelMappingRegister(),
            new RoleUpdateViewModelMappingRegister(),
            new PrimitiveRoleMappingRegister(),

            new ApiKeyCreateViewModelMappingRegister(),
            new ApiKeyUpdateViewModelMappingRegister(),
            new PrimitiveApiKeyMappingRegister(),

            new OrganizationKindMappingRegister(),

            new FeatureKindMappingRegister(),

            new UnitMeasurementMappingRegister(),

            new TerritoryPotentialMappingRegister(),

            new TerritorialBarrierMappingRegister(),

            new PublicPolicyMappingRegister(),

            new FeatureMappingRegister(),

            new ObjectiveMappingRegister(),

            new MacroprogramMappingRegister(),

            new InterestAreaMappingRegister(),

            new KeyVariableMappingRegister(),

            new PersonMappingRegister(),

            new OrganizationMappingRegister(),

            new ClassificationMappingRegister(),

            new StrategicAxeMappingRegister(),

            new StrategicProgramMappingRegister(),

            new StrategicProjectMappingRegister(),

            new UserTraceMappingRegister(),

            new RoleTraceMappingRegister(),

            new PersonTraceMappingRegister(),

            new StrategicProjectKindMappingRegister(),

            new OrganizationTraceMappingRegister(),

            new ApiKeyTraceMappingRegister(),

            new ClassificationTraceMappingRegister(),

            new FeatureKindTraceMappingRegister(),

            new StrategicLineTraceMappingRegister(),

            new FeatureTraceMappingRegister(),

            new InterestAreaTraceMappingRegister(),

            new KeyVariableTraceMappingRegister(),

            new MacroprogramTraceMappingRegister(),

            new ObjectiveTraceMappingRegister(),

            new SessionProfileUpdateViewModelMappingRegister(self.GetRequiredService<IHttpContextAccessor>())
        );
    }
}