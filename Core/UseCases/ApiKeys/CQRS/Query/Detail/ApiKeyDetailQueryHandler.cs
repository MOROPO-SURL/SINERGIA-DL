using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ApiKeyAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ApiKeyAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.CQRS.Query.Detail;

internal sealed class ApiKeyDetailQueryHandler :
    AbstractDetailQueryHandler<ApiKey, ApiKeyId, Guid, ApiKeyDetailQuery, ApiKeyDetailDto>,
    IRequestHandler<ApiKeyDetailQuery, ApiKeyDetailDto>
{
    public ApiKeyDetailQueryHandler(IApiKeyQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityQueryRepository, mapper)
    {
    }
}
