using Mapster;
using Microsoft.Extensions.Options;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Configurations;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.Authentication.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.InterestAreas.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.Macroprograms.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.Objectives.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.Organizations.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.Persons.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.PublicPolicies.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.SocialSupportDemands.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.StrategicAxes.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.StrategicLines.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.StrategicPrograms.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.UnitMeasurements.Mappings;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Extensions;

internal static class ServiceProviderExtensions
{
    public static IServiceProvider ApplyMappins(this IServiceProvider self)
    {
        IOptions<JWTConfiguration> jwtConfigurationOptions = self.GetService<IOptions<JWTConfiguration>>()!;

        TypeAdapterConfig.GlobalSettings.Apply(
            new AuthenticateCommandMappingRegister(),
            new AuthenticatedSessionDtoModelMappingRegister(jwtConfigurationOptions),

            new ObjectiveMappingRegister(),
            new PublicPolicyMappingRegister(),
            new UnitMeasurementMappingRegister(),
            new MacroprogramMappingRegister(),
            new InterestAreaMappingRegister(),
            new OrganizationMappingRegister(),
            new PersonMappingRegister(),
            new StrategicLineMappingRegister(),
            new StrategicAxeMappingRegister(),
            new StrategicProgramMappingRegister(),
            new SocialSupportDemandMappingRegister()
        );

        return self;
    }
}
