using Mapster;
using Microsoft.Extensions.Options;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Configurations;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.Authentication.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.Objectives.Mappings;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Extensions;

internal static class ServiceProviderExtensions
{
    public static IServiceProvider ApplyMappins(this IServiceProvider self)
    {
        IOptions<JWTConfiguration> jwtConfigurationOptions = self.GetService<IOptions<JWTConfiguration>>()!;

        TypeAdapterConfig.GlobalSettings.Apply(
            new AuthenticateCommandMappingRegister(),
            new AuthenticatedSessionDtoModelMappingRegister(jwtConfigurationOptions),

            new ObjectiveMappingRegister()
        );

        return self;
    }
}
