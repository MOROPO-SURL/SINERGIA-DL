using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritorialBarrierAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritorialBarrierAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Update;

internal sealed class TerritorialBarrierUpdateCommandHandler :
    AbstractUpdateCommandHandler<TerritorialBarrier, TerritorialBarrierId, Guid, TerritorialBarrierUpdateCommand, TerritorialBarrierDetailDto>,
    IRequestHandler<TerritorialBarrierUpdateCommand, TerritorialBarrierDetailDto>
{
    public TerritorialBarrierUpdateCommandHandler(ITerritorialBarrierQueryRepositoryPort entityQueryRepository, ITerritorialBarrierCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}