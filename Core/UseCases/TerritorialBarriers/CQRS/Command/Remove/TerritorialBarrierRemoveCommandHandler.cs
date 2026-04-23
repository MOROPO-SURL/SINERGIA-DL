using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritorialBarrierAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritorialBarrierAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Remove;

internal sealed class TerritorialBarrierRemoveCommandHandler :
    AbstractRemoveCommandHandler<TerritorialBarrier, TerritorialBarrierId, Guid, TerritorialBarrierRemoveCommand>,
    IRequestHandler<TerritorialBarrierRemoveCommand>
{
    public TerritorialBarrierRemoveCommandHandler(ITerritorialBarrierQueryRepositoryPort entityQueryRepository, ITerritorialBarrierCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}