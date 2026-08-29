using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritoryPotentialAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritoryPotentialAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.CQRS.Command.Remove;

internal sealed class TerritoryPotentialRemoveCommandHandler :
    AbstractRemoveCommandHandler<TerritoryPotential, TerritoryPotentialId, Guid, TerritoryPotentialRemoveCommand>,
    IRequestHandler<TerritoryPotentialRemoveCommand>
{
    public TerritoryPotentialRemoveCommandHandler(ITerritoryPotentialCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, mapper)
    {
    }
}