using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.StrategicProjects;

internal sealed class StrategicProjectQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<StrategicProject, StrategicProjectId, Guid>, IStrategicProjectQueryRepositoryPort
{
    public StrategicProjectQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}