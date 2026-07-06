using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Enumerations;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationKindAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationKindAggregate;

public class OrganizationKind : AbstractAuditableEntity<OrganizationKindId, Guid>, IAggregateRoot<OrganizationKindId, Guid>, IPriorizableEntity<OrganizationKindId, Guid>, IEnableableEntity<OrganizationKindId, Guid>, INamedEntity<OrganizationKindId, Guid>
{
    private OrganizationKind() : base(new OrganizationKindId(default)) { }

    public OrganizationKind(OrganizationKindId id, bool isEnabled, int priority, string name, DevelopmentActorProfileKind? developmentActorProfileKind = null, string? description = null) : base(id)
    {
        IsEnabled = isEnabled;
        Priority = priority;
        Name = name;
        DevelopmentActorProfileKind = developmentActorProfileKind;
        Description = description;
    }

    public bool IsEnabled { get; set; }

    public int Priority { get; set; }

    public string Name { get; set; } = null!;

    public DevelopmentActorProfileKind? DevelopmentActorProfileKind { get; set; }

    public string? Description { get; set; }
}
