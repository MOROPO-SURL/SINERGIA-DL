using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritorialBarrierAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritorialBarrierAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Archive;

internal sealed class TerritorialBarrierArchiveCommandHandler :
    AbstractArchiveCommandHandler<TerritorialBarrier, TerritorialBarrierId, Guid, TerritorialBarrierArchiveCommand>,
    IRequestHandler<TerritorialBarrierArchiveCommand>
{
    public TerritorialBarrierArchiveCommandHandler(ITerritorialBarrierCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}