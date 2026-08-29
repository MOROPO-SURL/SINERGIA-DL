using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UnitMeasurementAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UnitMeasurementAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.Ports.Repository;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Query.Paginate;

internal sealed class UnitMeasurementPaginateQueryHandler : 
    AbstractPaginateQueryHandler<UnitMeasurement, UnitMeasurementId, Guid, UnitMeasurementPaginateQuery, UnitMeasurementBasicDto>,
    IRequestHandler<UnitMeasurementPaginateQuery, PaginateQueryResultModel<UnitMeasurementBasicDto>>
{
    public UnitMeasurementPaginateQueryHandler(IUnitMeasurementQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<UnitMeasurement, object>> OrderExpression => entity => entity.Priority;
}
