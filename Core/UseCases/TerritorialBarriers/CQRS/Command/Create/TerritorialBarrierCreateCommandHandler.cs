using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritorialBarrierAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritorialBarrierAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Create;

internal sealed class TerritorialBarrierCreateCommandHandler :
    AbstractCreateCommandHandler<TerritorialBarrier, TerritorialBarrierId, Guid, TerritorialBarrierCreateCommand, TerritorialBarrierDetailDto>,
    IRequestHandler<TerritorialBarrierCreateCommand, TerritorialBarrierDetailDto>
{
    public TerritorialBarrierCreateCommandHandler(ITerritorialBarrierCommandRepositoryPort entityCommandRepository, ITerritorialBarrierQueryRepositoryPort entityQueryRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}