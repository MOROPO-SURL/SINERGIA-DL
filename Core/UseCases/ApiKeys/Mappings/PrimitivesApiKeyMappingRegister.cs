using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ApiKeyAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.Mappings;

internal sealed class PrimitivesApiKeyMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, ApiKeyId>()
            .MapWith(src => new ApiKeyId(src));
    }
}
