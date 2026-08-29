using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarrierTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarrierTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarrierTraces.CQRS.Query.List;

internal sealed class TerritorialBarrierTraceListQueryHandler :
    AbstractListQueryHandler<TerritorialBarrierTrace, TraceId, long, TerritorialBarrierTraceDetailDto, TerritorialBarrierTraceListQuery>,
    IRequestHandler<TerritorialBarrierTraceListQuery, TerritorialBarrierTraceDetailDto[]>
{
    public TerritorialBarrierTraceListQueryHandler(ITerritorialBarrierTraceQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<TerritorialBarrierTrace, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}