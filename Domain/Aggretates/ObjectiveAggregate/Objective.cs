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

    public Objective(ObjectiveId id, bool isArchived, bool enabled, int index, string title, ObjectiveAction[] actions, ObjectiveProjection[] projections, string? description = null) : base(id)
    {
        IsArchived = isArchived;
        IsEnabled = enabled;
        Index = index;
        Title = title;
        Description = description;

        this.actions = [.. actions];
        this.projections = [.. projections];
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
}