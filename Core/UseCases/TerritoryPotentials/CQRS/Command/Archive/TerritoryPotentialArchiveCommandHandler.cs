using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.CQRS.Command.Archive;

internal sealed class TerritoryPotentialArchiveCommandHandler :
    AbstractArchiveCommandHandler<TerritoryPotential, TerritoryPotentialId, Guid, TerritoryPotentialArchiveCommand>,
    IRequestHandler<TerritoryPotentialArchiveCommand>
{
    public TerritoryPotentialArchiveCommandHandler(ITerritoryPotentialCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}