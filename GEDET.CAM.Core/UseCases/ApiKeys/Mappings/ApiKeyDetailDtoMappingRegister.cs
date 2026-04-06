using Mapster;
using MOROPO.GEDET.CAM.Core.UseCases.ApiKeys.DTOs;
using MOROPO.GEDET.CAM.Core.UseCases.Permissions.DTOs;
using MOROPO.GEDET.CAM.Domain.Aggretates.ApiKeyAggregate;

namespace MOROPO.GEDET.CAM.Core.UseCases.ApiKeys.Mappings;

internal sealed class ApiKeyDetailDtoMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ApiKey, ApiKeyDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Permissions, src => src.PermissionBridges.Select(bridge => new PermissionDetailDto(bridge.LinkedId.Value, bridge.Linked!.Family, bridge.Linked!.Description)))
            .Map(dest => dest, src => src);
    }
}
