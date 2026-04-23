using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritorialBarrierAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritorialBarrierAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Update;

internal sealed class TerritorialBarrierUpdateCommandHandler :
    AbstractUpdateCommandHandler<TerritorialBarrier, TerritorialBarrierId, Guid, TerritorialBarrierUpdateCommand, TerritorialBarrierDetailDto>,
    IRequestHandler<TerritorialBarrierUpdateCommand, TerritorialBarrierDetailDto>
{
    public TerritorialBarrierUpdateCommandHandler(ITerritorialBarrierQueryRepositoryPort entityQueryRepository, ITerritorialBarrierCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}