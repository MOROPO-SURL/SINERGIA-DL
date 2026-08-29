using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLineTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLineTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLineTraces.CQRS.Query.Paginate;

internal sealed class StrategicLineTracePaginateQueryHandler :
AbstractPaginateQueryHandler<StrategicLineTrace, TraceId, long, StrategicLineTracePaginateQuery, StrategicLineTraceBasicDto>,
IRequestHandler<StrategicLineTracePaginateQuery, PaginateQueryResultModel<StrategicLineTraceBasicDto>>
{
    public StrategicLineTracePaginateQueryHandler(IStrategicLineTraceQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<StrategicLineTrace, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}
