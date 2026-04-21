using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate;

public class Objective : AbstractAuditableEntity<ObjectiveId, Guid>, IAggregateRoot<ObjectiveId, Guid>, IEnableableEntity<ObjectiveId, Guid>, IArchivableEntity<ObjectiveId, Guid>
{
    private readonly List<ObjectiveAction> actions = [];
    private readonly List<ObjectiveProjection> projections = [];
    private readonly List<ObjectiveChallenge> challenges = [];

    private Objective() : base(new ObjectiveId(default)) { }

    public Objective(ObjectiveId id, bool isArchived, bool enabled, int index, string title, ObjectiveChallenge[] challenges, ObjectiveProjection[] projections, ObjectiveAction[] actions, string? description = null) : base(id)
    {
        IsArchived = isArchived;
        IsEnabled = enabled;
        Index = index;
        Title = title;
        Description = description;

        this.challenges = [.. challenges];
        this.projections = [.. projections];
        this.actions = [.. actions];
    }

    public bool IsArchived { get; set; }

    public bool IsEnabled { get; set; }

    public int Index { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public IReadOnlyList<ObjectiveAction> Actions => [.. actions];

    public IReadOnlyList<ObjectiveProjection> Projections => [.. projections];

    public IReadOnlyList<ObjectiveChallenge> Challenges => [.. challenges];

    public List<ObjectiveKeyVariableBridge> KeyVariableBridges { get; set; } = null!;

    public void AddChallange(ObjectiveChallenge entity)
    {
        challenges.Add(entity);
    }

    public void RemoveChallange(ObjectiveChallenge entity)
    {
        challenges.Remove(challenges.First(_entity => _entity.Id == entity.Id));
    }

    public void AddProjection(ObjectiveProjection entity)
    {
        projections.Add(entity);
    }

    public void RemoveProjection(ObjectiveProjection entity)
    {
        projections.Remove(projections.First(_entity => _entity.Id == entity.Id));
    }

    public void AddAction(ObjectiveAction entity)
    {
        actions.Add(entity);
    }

    public void RemoveAction(ObjectiveAction entity)
    {
        actions.Remove(actions.First(_entity => _entity.Id == entity.Id));
    }
}