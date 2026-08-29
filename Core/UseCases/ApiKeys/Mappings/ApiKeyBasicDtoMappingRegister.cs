using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ApiKeyAggregate;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.Mappings;

internal sealed class ApiKeyBasicDtoMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ApiKey, ApiKeyBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);
    }
}
