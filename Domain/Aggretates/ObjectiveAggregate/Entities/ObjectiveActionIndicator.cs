using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UnitMeasurementAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UnitMeasurementAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate.Entities;

public sealed class ObjectiveActionIndicator : AbstractAuditableEntity<ObjectiveActionIndicatorId, Guid>, INamedEntity<ObjectiveActionIndicatorId, Guid>, IPriorizableEntity<ObjectiveActionIndicatorId, Guid>
{
    private readonly List<ObjectiveActionIndicatorMilestone> milestones = [];
    private readonly List<ObjectiveActionIndicatorChange> changes = [];

    private ObjectiveActionIndicator() : base(default) { }

    public ObjectiveActionIndicator(
        ObjectiveActionIndicatorId id,
        ObjectiveActionId actionId,
        ObjectiveId objectiveId,
        string name,
        UnitMeasurementId unitMeasurementId,
        int priority,
        IEnumerable<ObjectiveActionIndicatorMilestone> milestones,
        string? alias = null,
        UnitMeasurement? unitMeasurement = null) : base(id)
    {
        ActionId = actionId;
        ObjectiveId = objectiveId;
        Name = name;
        UnitMeasurementId = unitMeasurementId;
        Priority = priority;
        Alias = alias;
        UnitMeasurement = unitMeasurement;

        this.milestones = [.. milestones];
    }

    public ObjectiveId ObjectiveId { get; set; }

    public ObjectiveActionId ActionId { get; set; }

    public string Name { get; set; } = null!;

    public string? Alias { get; set; }

    public UnitMeasurementId UnitMeasurementId { get; set; }
    public UnitMeasurement? UnitMeasurement { get; set; }

    public int Priority { get; set; }

    public IReadOnlyList<ObjectiveActionIndicatorMilestone> Milestones => [.. milestones];

    public IReadOnlyList<ObjectiveActionIndicatorChange> Changes => [.. changes];

    public void AddMilestone(ObjectiveActionIndicatorMilestone entity) => milestones.Add(entity);

    public void RemoveMilestone(ObjectiveActionIndicatorMilestone entity) => milestones.Remove(entity);

    public void AddChange(ObjectiveActionIndicatorChange entity) => changes.Add(entity);

    public void RemoveChange(ObjectiveActionIndicatorChange entity) => changes.Remove(entity);
}