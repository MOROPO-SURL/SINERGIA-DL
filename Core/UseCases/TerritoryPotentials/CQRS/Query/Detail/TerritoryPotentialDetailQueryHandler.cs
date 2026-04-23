using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.CQRS.Query.Detail;

internal sealed class TerritoryPotentialDetailQueryHandler :
    AbstractDetailQueryHandler<TerritoryPotential, TerritoryPotentialId, Guid, TerritoryPotentialDetailQuery, TerritoryPotentialDetailDto>,
    IRequestHandler<TerritoryPotentialDetailQuery, TerritoryPotentialDetailDto>
{
    public TerritoryPotentialDetailQueryHandler(ITerritoryPotentialQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityQueryRepository, mapper)
    {
    }
}