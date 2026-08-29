using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritorialBarrierAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritorialBarrierAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.CQRS.Query.Paginate;

internal sealed class TerritorialBarrierPaginateQueryHandler :
    AbstractPaginateQueryHandler<TerritorialBarrier, TerritorialBarrierId, Guid, TerritorialBarrierPaginateQuery, TerritorialBarrierBasicDto>,
    IRequestHandler<TerritorialBarrierPaginateQuery, PaginateQueryResultModel<TerritorialBarrierBasicDto>>
{
    public TerritorialBarrierPaginateQueryHandler(ITerritorialBarrierQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<TerritorialBarrier, object>> OrderExpression => entity => entity.CreatedAt;
}