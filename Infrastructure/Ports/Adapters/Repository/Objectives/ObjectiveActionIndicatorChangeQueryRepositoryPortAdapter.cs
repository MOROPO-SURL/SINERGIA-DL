using Mapster;
using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Objectives;

internal sealed class ObjectiveActionIndicatorChangeQueryRepositoryPortAdapter : IObjectiveActionIndicatorChangeQueryRepositoryPort
{
    private readonly IQueryable<Objective> baseQueryableDbSet;

    public ObjectiveActionIndicatorChangeQueryRepositoryPortAdapter(DefaultDbContext dbContext)
    {
        baseQueryableDbSet = dbContext.Set<Objective>()
            .AsNoTracking()
            .AsSplitQuery()
            .IgnoreAutoIncludes()
            .Include(entity => entity.Actions).ThenInclude(entity => entity.Indicators).ThenInclude(entity => entity.Changes);
    }

    public IEnumerable<ObjectiveActionIndicatorChange> GetIndicatorChangeListByObjectiveActionIndicator(ObjectiveId objectiveId, ObjectiveActionId actionId, ObjectiveActionIndicatorId indicatorId)
    {
        List<ObjectiveActionIndicatorChange> result = [];

        Objective objective = baseQueryableDbSet.Single(entity => entity.Id == objectiveId);

        ObjectiveAction action = objective.Actions.Single(entity => entity.Id == actionId);

        ObjectiveActionIndicator indicator = action.Indicators.Single(entity => entity.Id == indicatorId);

        return indicator.Changes.OrderBy(entity => entity.Id);
    }

    public IEnumerable<ObjectiveActionIndicatorChange> GetIndicatorChangeLastsByObjective(ObjectiveId objectiveId)
    {
        List<ObjectiveActionIndicatorChange> result = [];

        Objective objective = baseQueryableDbSet.Single(entity => entity.Id == objectiveId);

        foreach (ObjectiveAction action in objective.Actions)
        {
            foreach (ObjectiveActionIndicator indicator in action.Indicators)
            {
                ObjectiveActionIndicatorChange? last = indicator.Changes.OrderByDescending(entity => entity.Id).FirstOrDefault();

                if (last == null) continue;

                result.Add(last);
            }
        }

        return result;
    }
}
