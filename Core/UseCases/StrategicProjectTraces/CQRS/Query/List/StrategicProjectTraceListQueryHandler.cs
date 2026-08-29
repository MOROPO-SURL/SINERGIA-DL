using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectTraces.CQRS.Query.List;

internal sealed class StrategicProjectTraceListQueryHandler :
    AbstractListQueryHandler<StrategicProjectTrace, TraceId, long, StrategicProjectTraceDetailDto, StrategicProjectTraceListQuery>,
    IRequestHandler<StrategicProjectTraceListQuery, StrategicProjectTraceDetailDto[]>
{
    public StrategicProjectTraceListQueryHandler(IStrategicProjectTraceQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<StrategicProjectTrace, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}