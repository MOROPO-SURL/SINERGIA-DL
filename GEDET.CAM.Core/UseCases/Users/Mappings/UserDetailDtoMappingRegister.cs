using Mapster;
using MOROPO.GEDET.CAM.Core.UseCases.Permissions.DTOs;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.DTOs;
using MOROPO.GEDET.CAM.Core.UseCases.Users.DTOs;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate;

namespace MOROPO.GEDET.CAM.Core.UseCases.Users.Mappings;

internal class UserDetailDtoMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, UserDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Roles, src => src.RoleBridges.Select(bridge => new RoleDetailDto(bridge.LinkedId.Value, bridge.Linked.Name, Array.Empty<PermissionDetailDto>(), bridge.Linked.Description)))
            .Map(dest => dest, src => src);
    }
}
