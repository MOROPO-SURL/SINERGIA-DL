using MOROPO.GEDET.CAM.Domain.Aggretates.ObjectiveAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.ObjectiveAggregate.Entities;

public class ObjectiveAction : AbstractEntity<ObjectiveActionId, Guid>
{
    private ObjectiveAction() : base(new ObjectiveActionId(default)) { }

    public ObjectiveAction(ObjectiveActionId id, int index, string title, string? description = null) : base(id)
    {
        Index = index;
        Title = title;
        Description = description;
    }

    public ObjectiveId ObjectiveId { get; set; }

    public int Index { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }
}