using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentialTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentialTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentialTraces.CQRS.Query.Detail;

internal sealed class TerritoryPotentialTraceDetailQueryHandler :
    AbstractDetailQueryHandler<TerritoryPotentialTrace, TraceId, long, TerritoryPotentialTraceDetailQuery, TerritoryPotentialTraceDetailDto>,
    IRequestHandler<TerritoryPotentialTraceDetailQuery, TerritoryPotentialTraceDetailDto>
{
    public TerritoryPotentialTraceDetailQueryHandler(ITerritoryPotentialTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}