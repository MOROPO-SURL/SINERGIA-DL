using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritorialBarrierAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritorialBarrierAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.TerritorialBarriers;

internal sealed class TerritorialBarrierCommandRepositoryPortAdapter : AbstractEntityCommandRepositoryPortAdapter<TerritorialBarrier, TerritorialBarrierId, Guid>, ITerritorialBarrierCommandRepositoryPort
{
    public TerritorialBarrierCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}