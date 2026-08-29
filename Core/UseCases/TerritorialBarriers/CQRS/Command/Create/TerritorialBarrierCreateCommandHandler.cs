using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritorialBarrierAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritorialBarrierAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Create;

internal sealed class TerritorialBarrierCreateCommandHandler :
    AbstractCreateCommandHandler<TerritorialBarrier, TerritorialBarrierId, Guid, TerritorialBarrierCreateCommand, TerritorialBarrierDetailDto>,
    IRequestHandler<TerritorialBarrierCreateCommand, TerritorialBarrierDetailDto>
{
    public TerritorialBarrierCreateCommandHandler(ITerritorialBarrierCommandRepositoryPort entityCommandRepository, ITerritorialBarrierQueryRepositoryPort entityQueryRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}