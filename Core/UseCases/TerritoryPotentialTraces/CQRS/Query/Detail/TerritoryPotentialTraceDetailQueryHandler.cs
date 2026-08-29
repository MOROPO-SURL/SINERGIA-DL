using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentialTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentialTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentialTraces.CQRS.Query.Detail;

internal sealed class TerritoryPotentialTraceDetailQueryHandler :
    AbstractDetailQueryHandler<TerritoryPotentialTrace, TraceId, long, TerritoryPotentialTraceDetailQuery, TerritoryPotentialTraceDetailDto>,
    IRequestHandler<TerritoryPotentialTraceDetailQuery, TerritoryPotentialTraceDetailDto>
{
    public TerritoryPotentialTraceDetailQueryHandler(ITerritoryPotentialTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}