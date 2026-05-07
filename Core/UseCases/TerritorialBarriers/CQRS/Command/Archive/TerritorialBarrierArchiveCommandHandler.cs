using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritorialBarrierAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritorialBarrierAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Archive;

internal sealed class TerritorialBarrierArchiveCommandHandler :
    AbstractArchiveCommandHandler<TerritorialBarrier, TerritorialBarrierId, Guid, TerritorialBarrierArchiveCommand>,
    IRequestHandler<TerritorialBarrierArchiveCommand>
{
    public TerritorialBarrierArchiveCommandHandler(ITerritorialBarrierCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}