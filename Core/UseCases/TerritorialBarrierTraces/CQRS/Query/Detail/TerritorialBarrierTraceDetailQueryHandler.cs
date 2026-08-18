using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarrierTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarrierTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarrierTraces.CQRS.Query.Detail;

internal sealed class TerritorialBarrierTraceDetailQueryHandler :
    AbstractDetailQueryHandler<TerritorialBarrierTrace, TraceId, long, TerritorialBarrierTraceDetailQuery, TerritorialBarrierTraceDetailDto>,
    IRequestHandler<TerritorialBarrierTraceDetailQuery, TerritorialBarrierTraceDetailDto>
{
    public TerritorialBarrierTraceDetailQueryHandler(ITerritorialBarrierTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}