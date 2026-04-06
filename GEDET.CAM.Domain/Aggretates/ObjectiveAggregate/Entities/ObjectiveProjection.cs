using MOROPO.GEDET.CAM.Domain.Aggretates.ObjectiveAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.ObjectiveAggregate.Entities;

public class ObjectiveProjection : AbstractAuditableEntity<ObjectiveProjectionId, Guid>
{
    public ObjectiveProjection(ObjectiveProjectionId id, int index, string title, string? description = null) : base(id)
    {
        Index = index;
        Title = title;
        Description = description;
    }

    public ObjectiveId ObjectiveId { get; set; }

    public int Index { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }
}