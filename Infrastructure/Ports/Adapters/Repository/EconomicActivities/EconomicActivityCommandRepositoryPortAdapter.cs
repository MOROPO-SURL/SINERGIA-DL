using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivities.Ports;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.EconomicActivityAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.EconomicActivityAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.EconomicActivities;

internal sealed class EconomicActivityCommandRepositoryPortAdapter : AbstractEntityCommandRepositoryPortAdapter<EconomicActivity, EconomicActivityId, int>, IEconomicActivityCommandRepositoryPort
{
    public EconomicActivityCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}