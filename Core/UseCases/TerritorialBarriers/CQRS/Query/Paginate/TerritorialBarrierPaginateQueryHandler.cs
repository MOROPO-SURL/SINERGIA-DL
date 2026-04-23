using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritorialBarrierAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritorialBarrierAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Query.Paginate;

internal sealed class TerritorialBarrierPaginateQueryHandler :
    AbstractPaginateQueryHandler<TerritorialBarrier, TerritorialBarrierId, Guid, TerritorialBarrierPaginateQuery, TerritorialBarrierBasicDto>,
    IRequestHandler<TerritorialBarrierPaginateQuery, PaginateQueryResultModel<TerritorialBarrierBasicDto>>
{
    public TerritorialBarrierPaginateQueryHandler(ITerritorialBarrierQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<TerritorialBarrier, bool>>? GlobalSelector => entity => !entity.IsArchived;

    protected override Expression<Func<TerritorialBarrier, object>> OrderExpression => entity => entity.CreatedAt;
}