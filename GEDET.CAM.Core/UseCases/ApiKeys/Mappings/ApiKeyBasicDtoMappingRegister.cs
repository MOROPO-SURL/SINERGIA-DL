using Mapster;
using MOROPO.GEDET.CAM.Core.UseCases.ApiKeys.DTOs;
using MOROPO.GEDET.CAM.Domain.Aggretates.ApiKeyAggregate;

namespace MOROPO.GEDET.CAM.Core.UseCases.ApiKeys.Mappings;

internal sealed class ApiKeyBasicDtoMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ApiKey, ApiKeyBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);
    }
}
