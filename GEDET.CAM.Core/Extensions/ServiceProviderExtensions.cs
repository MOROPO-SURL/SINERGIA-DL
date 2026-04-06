using Mapster;
using Microsoft.Extensions.DependencyInjection;
using MOROPO.GEDET.CAM.Core.Common.Ports.Service;
using MOROPO.GEDET.CAM.Core.UseCases.ApiKeys.Mappings;
using MOROPO.GEDET.CAM.Core.UseCases.Permissions.Mappings;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.Mappings;
using MOROPO.GEDET.CAM.Core.UseCases.Users.Mappings;
using MOROPO.GEDET.CAM.Domain.Common.Ports.Service;

namespace MOROPO.GEDET.CAM.Core.Extensions;

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
