using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentialTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentialTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentialTraces.CQRS.Query.List;

internal sealed class TerritoryPotentialTraceListQueryHandler :
    AbstractListQueryHandler<TerritoryPotentialTrace, TraceId, long, TerritoryPotentialTraceDetailDto, TerritoryPotentialTraceListQuery>,
    IRequestHandler<TerritoryPotentialTraceListQuery, TerritoryPotentialTraceDetailDto[]>
{
    public TerritoryPotentialTraceListQueryHandler(ITerritoryPotentialTraceQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<TerritoryPotentialTrace, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}