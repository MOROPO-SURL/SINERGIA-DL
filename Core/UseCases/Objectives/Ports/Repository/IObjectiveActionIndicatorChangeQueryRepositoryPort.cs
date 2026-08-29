using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate.Entities;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.Ports.Repository;

public interface IObjectiveActionIndicatorChangeQueryRepositoryPort
{
    IEnumerable<ObjectiveActionIndicatorChange> GetIndicatorChangeListByObjectiveActionIndicator(ObjectiveId objectiveId, ObjectiveActionId actionId, ObjectiveActionIndicatorId indicatorId);

    IEnumerable<ObjectiveActionIndicatorChange> GetIndicatorChangeLastsByObjective(ObjectiveId objectiveId);
}