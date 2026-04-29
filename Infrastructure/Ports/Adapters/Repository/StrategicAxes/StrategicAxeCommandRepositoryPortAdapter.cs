using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF; 
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.StrategicAxes;

internal sealed class StrategicAxeCommandRepositoryPortAdapter : AbstractEntityCommandRepositoryPortAdapter<StrategicAxe, StrategicAxeId, int>, IStrategicAxeCommandRepositoryPort
{
    public StrategicAxeCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}