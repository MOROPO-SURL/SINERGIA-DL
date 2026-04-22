using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationKindAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationKindAggregate;

public class OrganizationKind : AbstractAuditableEntity<OrganizationKindId, Guid>, IAggregateRoot<OrganizationKindId, Guid>, IPriorizableEntity<OrganizationKindId, Guid>, IArchivableEntity<OrganizationKindId, Guid>, IEnableableEntity<OrganizationKindId, Guid>, INamedEntity<OrganizationKindId, Guid>
{
    private OrganizationKind() : base(new OrganizationKindId(default)) { }

    public OrganizationKind(OrganizationKindId id, bool isEnabled, bool isArchived, int priority, string name, string? description = null) : base(id)
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
