using Mapster;
using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectAggregate.Entities;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.StrategicProjects;

internal sealed class StrategicProjectIndicatorChangeQueryRepositoryPortAdapter : IStrategicProjectIndicatorChangeQueryRepositoryPort
{
    private readonly IQueryable<StrategicProject> baseQueryableDbSet;

    public StrategicProjectIndicatorChangeQueryRepositoryPortAdapter(DefaultDbContext dbContext)
    {
        baseQueryableDbSet = dbContext.Set<StrategicProject>()
            .AsNoTracking()
            .AsSplitQuery()
            .IgnoreAutoIncludes()
            .Include(entity => entity.Indicators).ThenInclude(entity => entity.Changes);
    }

    public IEnumerable<ProjectIndicatorChange> GetIndicatorChangeListByProjectActionIndicator(StrategicProjectId programId, ProjectIndicatorId indicatorId)
    {
        List<ProjectIndicatorChange> result = [];

        StrategicProject program = baseQueryableDbSet.Single(entity => entity.Id == programId);

        ProjectIndicator indicator = program.Indicators.Single(entity => entity.Id == indicatorId);

        return indicator.Changes.OrderBy(entity => entity.Id);
    }

    public IEnumerable<ProjectIndicatorChange> GetIndicatorChangeLastsByProject(StrategicProjectId programId)
    {
        List<ProjectIndicatorChange> result = [];

        StrategicProject program = baseQueryableDbSet.Single(entity => entity.Id == programId);

        foreach (ProjectIndicator indicator in program.Indicators)
        {
            ProjectIndicatorChange? last = indicator.Changes.OrderByDescending(entity => entity.Id).FirstOrDefault();

            if (last == null) continue;

            result.Add(last);
        }

        return result;
    }
}
