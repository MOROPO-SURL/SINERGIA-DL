using MOROPO.GEDET.CAM.Domain.Aggretates.ObjectiveAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.ObjectiveAggregate.Entities;

public class ObjectiveChallenge : AbstractAuditableEntity<ObjectiveChallengeId>
{
    private ObjectiveChallenge() : base(new ObjectiveChallengeId(default)) { }

    public ObjectiveChallenge(ObjectiveChallengeId id, int index, string title, string? description = null) : base(id)
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
