using Mapster;
using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.StrategicPrograms;

internal sealed class StrategicProgramActionIndicatorChangeQueryRepositoryPortAdapter : IStrategicProgramActionIndicatorChangeQueryRepositoryPort
{
    private readonly IQueryable<StrategicProgram> baseQueryableDbSet;

    public StrategicProgramActionIndicatorChangeQueryRepositoryPortAdapter(DefaultDbContext dbContext)
    {
        baseQueryableDbSet = dbContext.Set<StrategicProgram>()
            .AsNoTracking()
            .AsSplitQuery()
            .IgnoreAutoIncludes()
            .Include(entity => entity.Actions).ThenInclude(entity => entity.Indicators).ThenInclude(entity => entity.Changes);
    }

    public IEnumerable<ProgramActionIndicatorChange> GetIndicatorChangeListByProgramActionIndicator(StrategicProgramId programId, ProgramActionId actionId, ProgramActionIndicatorId indicatorId)
    {
        List<ProgramActionIndicatorChange> result = [];

        StrategicProgram program = baseQueryableDbSet.Single(entity => entity.Id == programId);

        ProgramAction action = program.Actions.Single(entity => entity.Id == actionId);

        ProgramActionIndicator indicator = action.Indicators.Single(entity => entity.Id == indicatorId);

        return indicator.Changes.OrderBy(entity => entity.Id);
    }

    public IEnumerable<ProgramActionIndicatorChange> GetIndicatorChangeLastsByProgram(StrategicProgramId programId)
    {
        List<ProgramActionIndicatorChange> result = [];

        StrategicProgram program = baseQueryableDbSet.Single(entity => entity.Id == programId);

        foreach (ProgramAction action in program.Actions)
        {
            foreach (ProgramActionIndicator indicator in action.Indicators)
            {
                ProgramActionIndicatorChange? last = indicator.Changes.OrderByDescending(entity => entity.Id).FirstOrDefault();

                if (last == null) continue;

                result.Add(last);
            }
        }

        return result;
    }
}
