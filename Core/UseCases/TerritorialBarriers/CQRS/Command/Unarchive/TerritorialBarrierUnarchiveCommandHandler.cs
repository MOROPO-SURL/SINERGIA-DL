using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritorialBarrierAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritorialBarrierAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Unarchive;

internal sealed class TerritorialBarrierUnarchiveCommandHandler :
    AbstractUnarchiveCommandHandler<TerritorialBarrier, TerritorialBarrierId, Guid, TerritorialBarrierUnarchiveCommand>,
    IRequestHandler<TerritorialBarrierUnarchiveCommand>
{
    public TerritorialBarrierUnarchiveCommandHandler(ITerritorialBarrierCommandRepositoryPort entityCommandRepository, ITerritorialBarrierQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}