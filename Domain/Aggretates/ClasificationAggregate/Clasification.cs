using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClasificationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClasificationAggregate;

public class Clasification : AbstractAuditableEntity<ClasificationId, Guid>, IAggregateRoot<ClasificationId, Guid>, IArchivableEntity<ClasificationId, Guid>, IEnableableEntity<ClasificationId, Guid>, INamedEntity<ClasificationId, Guid>, IPriorizableEntity<ClasificationId, Guid>
{
    private Clasification() : base(new ClasificationId(default)) { }

    public Clasification(ClasificationId id, int priority, bool isEnabled, bool isArchived, string name, string? description = null) : base(id)
    {
        Priority = priority;
        Name = name;
        Description = description;
        IsEnabled = isEnabled;
        IsArchived = isArchived;
    }

    public int Priority { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsEnabled { get; set; }

    public bool IsArchived { get; set; }
}
