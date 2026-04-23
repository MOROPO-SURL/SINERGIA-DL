using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritorialBarrierAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritorialBarrierAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Query.Detail;

internal sealed class TerritorialBarrierDetailQueryHandler :
    AbstractDetailQueryHandler<TerritorialBarrier, TerritorialBarrierId, Guid, TerritorialBarrierDetailQuery, TerritorialBarrierDetailDto>,
    IRequestHandler<TerritorialBarrierDetailQuery, TerritorialBarrierDetailDto>
{
    public TerritorialBarrierDetailQueryHandler(ITerritorialBarrierQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityQueryRepository, mapper)
    {
    }
}
