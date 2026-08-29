using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate.Entities;

public class ObjectiveProjection : AbstractAuditableEntity<ObjectiveProjectionId, Guid>
{
    private ObjectiveProjection() : base(new ObjectiveProjectionId(default)) { }

    public ObjectiveProjection(ObjectiveProjectionId id, ObjectiveId objectiveId, int index, string title, string? description = null) : base(id)
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