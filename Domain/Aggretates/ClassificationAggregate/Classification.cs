using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClassificationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClassificationAggregate;

public class Classification : AbstractAuditableEntity<ClassificationId, Guid>, IAggregateRoot<ClassificationId, Guid>, IArchivableEntity<ClassificationId, Guid>, IEnableableEntity<ClassificationId, Guid>, INamedEntity<ClassificationId, Guid>, IPriorizableEntity<ClassificationId, Guid>
{
    private Classification() : base(new ClassificationId(default)) { }

    public Classification(ClassificationId id, int priority, bool isEnabled, bool isArchived, string name, string? description = null) : base(id)
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
