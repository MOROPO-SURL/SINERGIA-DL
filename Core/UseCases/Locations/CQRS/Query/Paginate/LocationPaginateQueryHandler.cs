using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Locations.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Locations.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.LocationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.LocationAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Locations.CQRS.Query.Paginate;

internal sealed class LocationPaginateQueryHandler :
    AbstractPaginateQueryHandler<Location, LocationId, Guid, LocationPaginateQuery, LocationDetailDto>,
    IRequestHandler<LocationPaginateQuery, PaginateQueryResultModel<LocationDetailDto>>
{
    public LocationPaginateQueryHandler(ILocationQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<Location, object>> OrderExpression => entity => entity.Name;
}