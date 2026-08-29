using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentialTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentialTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentialTraces.CQRS.Query.List;

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