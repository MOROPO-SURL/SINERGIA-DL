using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritorialBarrierAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritorialBarrierAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.CQRS.Query.List;

internal sealed class TerritorialBarrierListQueryHandler :
    AbstractListQueryHandler<TerritorialBarrier, TerritorialBarrierId, Guid, TerritorialBarrierDetailDto, TerritorialBarrierListQuery>,
    IRequestHandler<TerritorialBarrierListQuery, TerritorialBarrierDetailDto[]>
{
    public TerritorialBarrierListQueryHandler(ITerritorialBarrierQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}