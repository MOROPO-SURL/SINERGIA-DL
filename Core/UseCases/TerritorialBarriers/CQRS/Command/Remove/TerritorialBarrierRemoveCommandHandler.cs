using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritorialBarrierAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritorialBarrierAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Remove;

internal sealed class TerritorialBarrierRemoveCommandHandler :
    AbstractRemoveCommandHandler<TerritorialBarrier, TerritorialBarrierId, Guid, TerritorialBarrierRemoveCommand>,
    IRequestHandler<TerritorialBarrierRemoveCommand>
{
    public TerritorialBarrierRemoveCommandHandler(ITerritorialBarrierCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, mapper)
    {
    }
}