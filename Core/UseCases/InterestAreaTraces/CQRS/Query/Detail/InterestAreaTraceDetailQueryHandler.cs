using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreaTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreaTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreaTraces.CQRS.Query.Detail;

internal sealed class InterestAreaTraceDetailQueryHandler :
AbstractDetailQueryHandler<InterestAreaTrace, TraceId, long, InterestAreaTraceDetailQuery, InterestAreaTraceDetailDto>,
IRequestHandler<InterestAreaTraceDetailQuery, InterestAreaTraceDetailDto>
{
    public InterestAreaTraceDetailQueryHandler(IInterestAreaTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}
