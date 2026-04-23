using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.CQRS.Command.Remove;

internal sealed class TerritoryPotentialRemoveCommandHandler :
    AbstractRemoveCommandHandler<TerritoryPotential, TerritoryPotentialId, Guid, TerritoryPotentialRemoveCommand>,
    IRequestHandler<TerritoryPotentialRemoveCommand>
{
    public TerritoryPotentialRemoveCommandHandler(ITerritoryPotentialQueryRepositoryPort entityQueryRepository, ITerritoryPotentialCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}