using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritoryPotentialAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritoryPotentialAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.CQRS.Query.Paginate;

internal sealed class TerritoryPotentialPaginateQueryHandler :
    AbstractPaginateQueryHandler<TerritoryPotential, TerritoryPotentialId, Guid, TerritoryPotentialPaginateQuery, TerritoryPotentialBasicDto>,
    IRequestHandler<TerritoryPotentialPaginateQuery, PaginateQueryResultModel<TerritoryPotentialBasicDto>>
{
    public TerritoryPotentialPaginateQueryHandler(ITerritoryPotentialQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<TerritoryPotential, object>> OrderExpression => entity => entity.CreatedAt;
}