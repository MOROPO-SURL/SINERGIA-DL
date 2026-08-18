using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarrierTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarrierTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarrierTraces.CQRS.Query.Paginate;

internal sealed class TerritorialBarrierTracePaginateQueryHandler :
AbstractPaginateQueryHandler<TerritorialBarrierTrace, TraceId, long, TerritorialBarrierTracePaginateQuery, TerritorialBarrierTraceBasicDto>,
IRequestHandler<TerritorialBarrierTracePaginateQuery, PaginateQueryResultModel<TerritorialBarrierTraceBasicDto>>
{
    public TerritorialBarrierTracePaginateQueryHandler(ITerritorialBarrierTraceQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<TerritorialBarrierTrace, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}