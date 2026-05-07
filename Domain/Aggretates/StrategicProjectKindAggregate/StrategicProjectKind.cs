using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectKindAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectKindAggregate;

public class StrategicProjectKind : AbstractAuditableEntity<StrategicProjectKindId, Guid>, IAggregateRoot<StrategicProjectKindId, Guid>, IPriorizableEntity<StrategicProjectKindId, Guid>, IArchivableEntity<StrategicProjectKindId, Guid>, IEnableableEntity<StrategicProjectKindId, Guid>, INamedEntity<StrategicProjectKindId, Guid>
{
    private StrategicProjectKind() : base(new StrategicProjectKindId(default)) { }

    public StrategicProjectKind(StrategicProjectKindId id, bool isEnabled, bool isArchived, int priority, string name, string? description = null) : base(id)
    {
        IsEnabled = isEnabled;
        IsArchived = isArchived;
        Priority = priority;
        Name = name;
        Description = description;
    }

    public bool IsEnabled { get; set; }

    public bool IsArchived { get; set; }

    public int Priority { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}