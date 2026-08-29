using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurementTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurementTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurementTraces.CQRS.Query.List;

internal sealed class UnitMeasurementTraceListQueryHandler :
    AbstractListQueryHandler<UnitMeasurementTrace, TraceId, long, UnitMeasurementTraceDetailDto, UnitMeasurementTraceListQuery>,
    IRequestHandler<UnitMeasurementTraceListQuery, UnitMeasurementTraceDetailDto[]>
{
    public UnitMeasurementTraceListQueryHandler(IUnitMeasurementTraceQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<UnitMeasurementTrace, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}