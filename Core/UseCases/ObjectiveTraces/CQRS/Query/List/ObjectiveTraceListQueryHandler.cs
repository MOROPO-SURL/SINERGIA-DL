using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ObjectiveTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ObjectiveTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ObjectiveTraces.CQRS.Query.List;

internal sealed class ObjectiveTraceListQueryHandler :
    AbstractListQueryHandler<ObjectiveTrace, TraceId, long, ObjectiveTraceDetailDto, ObjectiveTraceListQuery>,
    IRequestHandler<ObjectiveTraceListQuery, ObjectiveTraceDetailDto[]>
{
    public ObjectiveTraceListQueryHandler(IObjectiveTraceQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<ObjectiveTrace, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}