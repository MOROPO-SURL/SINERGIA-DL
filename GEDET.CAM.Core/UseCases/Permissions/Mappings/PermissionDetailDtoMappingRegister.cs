using Mapster;
using MOROPO.GEDET.CAM.Core.UseCases.Permissions.DTOs;
using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate;

namespace MOROPO.GEDET.CAM.Core.UseCases.Permissions.Mappings;

internal class PermissionDetailDtoMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Permission, PermissionDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);
    }
}
