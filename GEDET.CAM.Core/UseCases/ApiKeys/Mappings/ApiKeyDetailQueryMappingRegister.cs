using Mapster;
using MOROPO.GEDET.CAM.Core.UseCases.ApiKeys.CQRS.Query.Detail;
using MOROPO.GEDET.CAM.Domain.Aggretates.ApiKeyAggregate.Values;

namespace MOROPO.GEDET.CAM.Core.UseCases.ApiKeys.Mappings;

internal sealed class ApiKeyKeyDetailQueryMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ApiKeyDetailQuery, ApiKeyId>()
            .MapWith(src => new ApiKeyId(src.Id));
    }
}