using MapsterMapper;
using MediatR;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Query.Detail;
using MOROPO.GEDET.CAM.Core.UseCases.ApiKeys.DTOs;
using MOROPO.GEDET.CAM.Core.UseCases.ApiKeys.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Aggretates.ApiKeyAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.ApiKeyAggregate;

namespace MOROPO.GEDET.CAM.Core.UseCases.ApiKeys.CQRS.Query.Detail;

internal sealed class ApiKeyDetailQueryHandler :
    AbstractDetailQueryHandler<ApiKey, ApiKeyId, Guid, ApiKeyDetailQuery, ApiKeyDetailDto>,
    IRequestHandler<ApiKeyDetailQuery, ApiKeyDetailDto>
{
    public ApiKeyDetailQueryHandler(IApiKeyQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityQueryRepository, mapper)
    {
    }
}
