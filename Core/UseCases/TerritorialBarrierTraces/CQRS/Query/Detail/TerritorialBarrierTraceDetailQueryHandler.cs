using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarrierTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarrierTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarrierTraces.CQRS.Query.Detail;

internal sealed class TerritorialBarrierTraceDetailQueryHandler :
    AbstractDetailQueryHandler<TerritorialBarrierTrace, TraceId, long, TerritorialBarrierTraceDetailQuery, TerritorialBarrierTraceDetailDto>,
    IRequestHandler<TerritorialBarrierTraceDetailQuery, TerritorialBarrierTraceDetailDto>
{
    public TerritorialBarrierTraceDetailQueryHandler(ITerritorialBarrierTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}