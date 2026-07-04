using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.Ports;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.EconomicActivities;

internal sealed class EconomicActivityCommandRepositoryPortAdapter : AbstractEntityCommandRepositoryPortAdapter<EconomicActivity, EconomicActivityId, int>, IEconomicActivityCommandRepositoryPort
{
    public EconomicActivityCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}