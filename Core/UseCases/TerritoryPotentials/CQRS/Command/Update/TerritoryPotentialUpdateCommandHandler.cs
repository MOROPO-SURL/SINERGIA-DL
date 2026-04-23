using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.CQRS.Command.Update;

internal sealed class TerritoryPotentialUpdateCommandHandler :
    AbstractUpdateCommandHandler<TerritoryPotential, TerritoryPotentialId, Guid, TerritoryPotentialUpdateCommand, TerritoryPotentialDetailDto>,
    IRequestHandler<TerritoryPotentialUpdateCommand, TerritoryPotentialDetailDto>
{
    public TerritoryPotentialUpdateCommandHandler(ITerritoryPotentialQueryRepositoryPort entityQueryRepository, ITerritoryPotentialCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}