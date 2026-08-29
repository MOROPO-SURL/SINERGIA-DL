using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicAxeAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicAxeAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF; 
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.StrategicAxes;

internal sealed class StrategicAxeCommandRepositoryPortAdapter : AbstractEntityCommandRepositoryPortAdapter<StrategicAxe, StrategicAxeId, int>, IStrategicAxeCommandRepositoryPort
{
    public StrategicAxeCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}