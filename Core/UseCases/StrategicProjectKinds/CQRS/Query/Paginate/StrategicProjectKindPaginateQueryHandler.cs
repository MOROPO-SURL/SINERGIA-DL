using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectKindAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectKindAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.CQRS.Query.Paginate;

internal sealed class StrategicProjectKindPaginateQueryHandler :
    AbstractPaginateQueryHandler<StrategicProjectKind, StrategicProjectKindId, Guid, StrategicProjectKindPaginateQuery, StrategicProjectKindBasicDto>,
    IRequestHandler<StrategicProjectKindPaginateQuery, PaginateQueryResultModel<StrategicProjectKindBasicDto>>
{
    public StrategicProjectKindPaginateQueryHandler(IStrategicProjectKindQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<StrategicProjectKind, object>> OrderExpression => entity => entity.Priority;
}