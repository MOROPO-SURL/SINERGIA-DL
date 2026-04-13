using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.ApiKeys.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Authentication.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Roles.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Users.Mappings;

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
            new PrimitiveApiKeyMappingRegister()
        );
    }
}
