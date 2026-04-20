using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Entities;

public class ObjectiveProjection : AbstractAuditableEntity<ObjectivActionId, Guid>
{
    private ObjectiveProjection() : base(new ObjectivActionId(default)) { }

    public ObjectiveProjection(ObjectivActionId id, ObjectiveId objectiveId, int index, string title, string? description = null) : base(id)
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