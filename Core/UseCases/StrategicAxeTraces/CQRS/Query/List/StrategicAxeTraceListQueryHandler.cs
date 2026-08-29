using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxeTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxeTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxeTraces.CQRS.Query.List;

internal sealed class StrategicAxeTraceListQueryHandler :
    AbstractListQueryHandler<StrategicAxeTrace, TraceId, long, StrategicAxeTraceDetailDto, StrategicAxeTraceListQuery>,
    IRequestHandler<StrategicAxeTraceListQuery, StrategicAxeTraceDetailDto[]>
{
    public StrategicAxeTraceListQueryHandler(IStrategicAxeTraceQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<StrategicAxeTrace, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}