using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.CQRS.Command.Create;

internal sealed class TerritoryPotentialCreateCommandHandler :
    AbstractCreateCommandHandler<TerritoryPotential, TerritoryPotentialId, Guid, TerritoryPotentialCreateCommand, TerritoryPotentialDetailDto>,
    IRequestHandler<TerritoryPotentialCreateCommand, TerritoryPotentialDetailDto>
{
    public TerritoryPotentialCreateCommandHandler(ITerritoryPotentialCommandRepositoryPort entityCommandRepository, ITerritoryPotentialQueryRepositoryPort entityQueryRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}