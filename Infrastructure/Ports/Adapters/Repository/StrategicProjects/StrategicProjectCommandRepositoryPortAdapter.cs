using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.StrategicProjects;

internal sealed class StrategicProjectCommandRepositoryPortAdapter : AbstractEntityCommandRepositoryPortAdapter<StrategicProject, StrategicProjectId, Guid>, IStrategicProjectCommandRepositoryPort
{
    public StrategicProjectCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<StrategicProject> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet().AsSplitQuery();
    }
}