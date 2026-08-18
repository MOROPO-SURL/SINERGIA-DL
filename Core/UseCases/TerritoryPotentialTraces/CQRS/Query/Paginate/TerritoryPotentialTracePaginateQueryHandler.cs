using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentialTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentialTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentialTraces.CQRS.Query.Paginate;

internal sealed class TerritoryPotentialTracePaginateQueryHandler :
AbstractPaginateQueryHandler<TerritoryPotentialTrace, TraceId, long, TerritoryPotentialTracePaginateQuery, TerritoryPotentialTraceBasicDto>,
IRequestHandler<TerritoryPotentialTracePaginateQuery, PaginateQueryResultModel<TerritoryPotentialTraceBasicDto>>
{
    public TerritoryPotentialTracePaginateQueryHandler(ITerritoryPotentialTraceQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<TerritoryPotentialTrace, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}