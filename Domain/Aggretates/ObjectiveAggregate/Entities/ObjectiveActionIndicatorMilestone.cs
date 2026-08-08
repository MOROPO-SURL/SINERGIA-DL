using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Entities;

public sealed class ObjectiveActionIndicatorMilestone : AbstractEntity<ObjectiveActionIndicatorMilestoneId, Guid>
{
    private ObjectiveActionIndicatorMilestone() : base(default) { }

    public ObjectiveActionIndicatorMilestone(ObjectiveActionIndicatorMilestoneId id, ObjectiveActionIndicatorId indicatorId, ObjectiveActionId actionId, ObjectiveId objectiveId, DateOnly at, float amount, string? description = null) : base(id)
    {
        ObjectiveId = objectiveId;
        ActionId = actionId;
        IndicatorId = indicatorId;
        Amount = amount;
        Description = description;
    }

    public ObjectiveId ObjectiveId { get; set; }

    public ObjectiveActionId ActionId { get; set; }

    public ObjectiveActionIndicatorId IndicatorId { get; set; }

    public DateOnly At { get; set; }

    public float Amount { get; set; }

    public string? Description { get; set; }
}
