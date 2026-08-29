using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeaTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeaTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeaTraces.CQRS.Query.Paginate;

internal sealed class StrategicProjectIdeaTracePaginateQueryHandler :
AbstractPaginateQueryHandler<StrategicProjectIdeaTrace, TraceId, long, StrategicProjectIdeaTracePaginateQuery, StrategicProjectIdeaTraceBasicDto>,
IRequestHandler<StrategicProjectIdeaTracePaginateQuery, PaginateQueryResultModel<StrategicProjectIdeaTraceBasicDto>>
{
    public StrategicProjectIdeaTracePaginateQueryHandler(IStrategicProjectIdeaTraceQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<StrategicProjectIdeaTrace, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}