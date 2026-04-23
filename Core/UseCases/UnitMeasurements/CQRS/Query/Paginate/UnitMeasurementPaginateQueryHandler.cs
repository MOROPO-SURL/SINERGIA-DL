using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UnitMeasurementAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UnitMeasurementAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.Ports.Repository;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.CQRS.Query.Paginate;

internal sealed class UnitMeasurementPaginateQueryHandler: AbstractPaginateQueryHandler<UnitMeasurement, UnitMeasurementId, Guid, UnitMeasurementPaginateQuery, UnitMeasurementBasicDto>,
IRequestHandler<UnitMeasurementPaginateQuery, PaginateQueryResultModel<UnitMeasurementBasicDto>>
{
    public UnitMeasurementPaginateQueryHandler(IUnitMeasurementQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<UnitMeasurement, bool>>? GlobalSelector => entity => !entity.IsArchived;

    protected override Expression<Func<UnitMeasurement, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}
