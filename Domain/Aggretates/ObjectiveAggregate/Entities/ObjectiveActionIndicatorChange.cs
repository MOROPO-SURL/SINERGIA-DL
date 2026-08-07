using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Entities;

public sealed class ObjectiveActionIndicatorChange : AbstractEntity<ObjectiveActionIndicatorChangeId, DateTime>
{
    private ObjectiveActionIndicatorChange() : base(default) { }

    public ObjectiveActionIndicatorChange(ObjectiveActionIndicatorChangeId id, ObjectiveId objectiveId, ObjectiveActionId actionId, ObjectiveActionIndicatorId indicatorId, float amount, string? context = null) : base(id)
    {
        ObjectiveId = objectiveId;
        ActionId = actionId;
        IndicatorId = indicatorId;
        Amount = amount;
        Context = context;
    }

    public ObjectiveId ObjectiveId { get; set; }

    public ObjectiveActionId ActionId { get; set; }

    public ObjectiveActionIndicatorId IndicatorId { get; set; }

    public float Amount { get; set; }

    public string? Context { get; set; }
}
