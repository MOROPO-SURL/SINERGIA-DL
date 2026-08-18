using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurementTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurementTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurementTraces.CQRS.Query.Paginate;

internal sealed class UnitMeasurementTracePaginateQueryHandler :
AbstractPaginateQueryHandler<UnitMeasurementTrace, TraceId, long, UnitMeasurementTracePaginateQuery, UnitMeasurementTraceBasicDto>,
IRequestHandler<UnitMeasurementTracePaginateQuery, PaginateQueryResultModel<UnitMeasurementTraceBasicDto>>
{
    public UnitMeasurementTracePaginateQueryHandler(IUnitMeasurementTraceQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<UnitMeasurementTrace, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}