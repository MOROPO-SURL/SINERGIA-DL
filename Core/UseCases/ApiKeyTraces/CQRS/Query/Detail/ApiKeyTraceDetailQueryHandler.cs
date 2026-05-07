using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeyTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.CQRS.Query.Detail;

internal sealed class ApiKeyTraceDetailQueryHandler :
    AbstractDetailQueryHandler<ApiKeyTrace, TraceId, long, ApiKeyTraceDetailQuery, ApiKeyTraceDetailDto>,
    IRequestHandler<ApiKeyTraceDetailQuery, ApiKeyTraceDetailDto>
{
    public ApiKeyTraceDetailQueryHandler(IApiKeyTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}