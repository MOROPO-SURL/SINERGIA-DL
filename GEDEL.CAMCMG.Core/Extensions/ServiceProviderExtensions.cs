using Mapster;
using Microsoft.Extensions.DependencyInjection;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Permissions.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.Mappings;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Extensions;

public static class ServiceProviderExtensions
{
    public static void ApplyCoreMappings(this IServiceProvider provider)
    {
        IStringHashingServicePort stringHashingService = provider.GetService<IStringHashingServicePort>()!;

        TypeAdapterConfig.GlobalSettings.Apply(
            new UserDetailDtoMappingRegister(),
            new UserBasicDtoMappingRegister(provider.GetService<IDataIntegrityServicePort>()!),
            new UserKeyDetailQueryMappingRegister(),
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
            new ApiKeyKeyDetailQueryMappingRegister(),

            new PermissionDetailDtoMappingRegister()
        );
    }
}
