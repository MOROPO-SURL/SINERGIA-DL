using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate.Entities;

public class ObjectiveChallenge : AbstractAuditableEntity<ObjectiveChallengeId, Guid>
{
    private ObjectiveChallenge() : base(new ObjectiveChallengeId(default)) { }

    public ObjectiveChallenge(ObjectiveChallengeId id, ObjectiveId objectiveId, int index, string title, string? description = null) : base(id)
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

    public override bool Equals(object? obj)
    {
        if (obj == null || obj is not ObjectiveChallenge entity) return false;

        return Id.Equals(entity.Id);
    }

    public override int GetHashCode()
    {
       return Id.GetHashCode();
    }
}