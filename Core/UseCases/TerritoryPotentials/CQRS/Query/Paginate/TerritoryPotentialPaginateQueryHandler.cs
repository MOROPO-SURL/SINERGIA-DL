using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.CQRS.Query.Paginate;

internal sealed class TerritoryPotentialPaginateQueryHandler :
    AbstractPaginateQueryHandler<TerritoryPotential, TerritoryPotentialId, Guid, TerritoryPotentialPaginateQuery, TerritoryPotentialBasicDto>,
    IRequestHandler<TerritoryPotentialPaginateQuery, PaginateQueryResultModel<TerritoryPotentialBasicDto>>
{
    public TerritoryPotentialPaginateQueryHandler(ITerritoryPotentialQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<TerritoryPotential, bool>>? GlobalSelector => entity => !entity.IsArchived;

    protected override Expression<Func<TerritoryPotential, object>> OrderExpression => entity => entity.CreatedAt;
}