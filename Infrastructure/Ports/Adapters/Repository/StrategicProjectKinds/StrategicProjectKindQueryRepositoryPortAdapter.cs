using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectKindAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectKindAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.StrategicProjectKinds;

internal sealed class StrategicProjectKindQueryRepositoryPortAdapter :
    AbstractEntityQueryRepositoryPortAdapter<StrategicProjectKind, StrategicProjectKindId, Guid>,
    IStrategicProjectKindQueryRepositoryPort
{
    public StrategicProjectKindQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}