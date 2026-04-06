using Mapster;
using MOROPO.GEDET.CAM.Core.UseCases.Permissions.DTOs;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.DTOs;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate;

namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.Mappings;

internal class RoleDetailDtoMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Role, RoleDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Permissions, src => src.PermissionBridges.Select(bridge => new PermissionDetailDto(bridge.LinkedId.Value, bridge.Linked!.Family, bridge.Linked!.Description)))
            .Map(dest => dest, src => src);
    }
}
