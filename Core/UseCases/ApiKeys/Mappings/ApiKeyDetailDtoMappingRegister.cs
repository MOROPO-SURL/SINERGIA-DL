using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Permissions.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ApiKeyAggregate;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.Mappings;

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
