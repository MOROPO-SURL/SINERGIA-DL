using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritorialBarrierAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritorialBarrierAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.TerritorialBarriers;

internal sealed class TerritorialBarrierCommandRepositoryPortAdapter : AbstractEntityCommandRepositoryPortAdapter<TerritorialBarrier, TerritorialBarrierId, Guid>, ITerritorialBarrierCommandRepositoryPort
{
    public TerritorialBarrierCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}