using MOROPO.GEDET.CAM.Domain.Aggretates.ObjectiveAggregate.Entities;
using MOROPO.GEDET.CAM.Domain.Aggretates.ObjectiveAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Bridges;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.ObjectiveAggregate;

public class Objective : AbstractAuditableEntity<ObjectiveId>, IAggregateRoot<ObjectiveId>, IEnableableEntity<ObjectiveId>, IArchivableEntity<ObjectiveId>
{
    private readonly List<ObjectiveAction> actions = [];
    private readonly List<ObjectiveProjection> projections = [];
    private readonly List<ObjectiveChallenge> challenges = [];

    private Objective() : base(new ObjectiveId(default)) { }

    public Objective(ObjectiveId id, bool isArchived, bool enabled, int index, string title, ObjectiveAction[] actions, ObjectiveProjection[] projections, string? description = null) : base(id)
    {
        IsArchived = isArchived;
        Enabled = enabled;
        Index = index;
        Title = title;
        Description = description;

        this.actions = [.. actions];
        this.projections = [.. projections];
    }

    public bool IsArchived { get; set; }

    public bool Enabled { get; set; }

    public int Index { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public ObjectiveAction[] Actions => [.. actions];

    public ObjectiveProjection[] Projections => [.. projections];

    public ObjectiveChallenge[] Challenges => [.. challenges];

    public List<ObjectiveKeyVariableBridge> KeyVariableBridges { get; set; } = null!;
}