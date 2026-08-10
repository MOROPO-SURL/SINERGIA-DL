using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.Ports.Repository;

public interface IObjectiveActionIndicatorChangeQueryRepositoryPort
{
    IEnumerable<ObjectiveActionIndicatorChange> GetIndicatorChangeListByObjectiveActionIndicator(ObjectiveId objectiveId, ObjectiveActionId actionId, ObjectiveActionIndicatorId indicatorId);

    IEnumerable<ObjectiveActionIndicatorChange> GetIndicatorChangeLastsByObjective(ObjectiveId objectiveId);
}