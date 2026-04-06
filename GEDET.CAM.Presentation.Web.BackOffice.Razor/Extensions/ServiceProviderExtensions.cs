using Mapster;
using MOROPO.GEDET.CAM.Presentation.Web.BackOffice.Razor.Models.View.Authentication.Mappings;
using MOROPO.GEDET.CAM.Presentation.Web.BackOffice.Razor.Models.View.Roles.Mappings;
using MOROPO.GEDET.CAM.Presentation.Web.BackOffice.Razor.Models.View.Users.Mappings;

namespace MOROPO.GEDET.CAM.Presentation.Web.BackOffice.Razor.Extensions;

internal static class ServiceProviderExtensions
{
    public static void ApplyPresentationMappings(this IServiceProvider provider)
    {
        TypeAdapterConfig.GlobalSettings.Apply(
            new AuthenticateRequestModelMappingRegister(),

            new UserCreateViewModelMappingRegister(),
            new UserUpdateViewModelMappingRegister(),
            new PrimitiveUserMappingRegister(),

            new RoleCreateViewModelMappingRegister(),
            new RoleUpdateViewModelMappingRegister(),
            new PrimitiveRoleMappingRegister()
        );
    }
}
