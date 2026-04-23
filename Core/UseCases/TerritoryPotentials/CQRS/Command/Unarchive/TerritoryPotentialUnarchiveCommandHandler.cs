using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.CQRS.Command.Unarchive;

internal sealed class TerritoryPotentialUnarchiveCommandHandler :
    AbstractUnarchiveCommandHandler<TerritoryPotential, TerritoryPotentialId, Guid, TerritoryPotentialUnarchiveCommand>,
    IRequestHandler<TerritoryPotentialUnarchiveCommand>
{
    public TerritoryPotentialUnarchiveCommandHandler(ITerritoryPotentialCommandRepositoryPort entityCommandRepository, ITerritoryPotentialQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}