using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritorialBarrierAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritorialBarrierAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Query.List;

internal sealed class TerritorialBarrierListQueryHandler :
    AbstractListQueryHandler<TerritorialBarrier, TerritorialBarrierId, Guid, TerritorialBarrierDetailDto, TerritorialBarrierListQuery>,
    IRequestHandler<TerritorialBarrierListQuery, TerritorialBarrierDetailDto[]>
{
    public TerritorialBarrierListQueryHandler(ITerritorialBarrierQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}