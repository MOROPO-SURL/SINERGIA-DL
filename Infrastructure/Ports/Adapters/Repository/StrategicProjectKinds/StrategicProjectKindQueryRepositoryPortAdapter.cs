using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectKindAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectKindAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.StrategicProjectKinds;

internal sealed class StrategicProjectKindQueryRepositoryPortAdapter :
    AbstractEntityQueryRepositoryPortAdapter<StrategicProjectKind, StrategicProjectKindId, Guid>,
    IStrategicProjectKindQueryRepositoryPort
{
    public StrategicProjectKindQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}