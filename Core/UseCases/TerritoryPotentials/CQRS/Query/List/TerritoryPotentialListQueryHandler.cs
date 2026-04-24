using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.CQRS.Query.List;

internal sealed class TerritoryPotentialListQueryHandler :
    AbstractListQueryHandler<TerritoryPotential, TerritoryPotentialId, Guid, TerritoryPotentialDetailDto, TerritoryPotentialListQuery>,
    IRequestHandler<TerritoryPotentialListQuery, TerritoryPotentialDetailDto[]>
{
    public TerritoryPotentialListQueryHandler(ITerritoryPotentialQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}