using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Entities;

public class ObjectiveAction : AbstractEntity<ObjectiveActionId, Guid>
{
    private ObjectiveAction() : base(new ObjectiveActionId(default)) { }

    public ObjectiveAction(ObjectiveActionId id, ObjectiveId objectiveId, int index, string title, string? description = null) : base(id)
    {
        ObjectiveId = objectiveId;
        Index = index;
        Title = title;
        Description = description;
    }

    public ObjectiveId ObjectiveId { get; set; }

    public int Index { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }
}