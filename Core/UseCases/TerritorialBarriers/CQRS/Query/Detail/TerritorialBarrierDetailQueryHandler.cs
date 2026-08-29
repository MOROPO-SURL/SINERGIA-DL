using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritorialBarrierAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritorialBarrierAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.CQRS.Query.Detail;

internal sealed class TerritorialBarrierDetailQueryHandler :
    AbstractDetailQueryHandler<TerritorialBarrier, TerritorialBarrierId, Guid, TerritorialBarrierDetailQuery, TerritorialBarrierDetailDto>,
    IRequestHandler<TerritorialBarrierDetailQuery, TerritorialBarrierDetailDto>
{
    public TerritorialBarrierDetailQueryHandler(ITerritorialBarrierQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityQueryRepository, mapper)
    {
    }
}
