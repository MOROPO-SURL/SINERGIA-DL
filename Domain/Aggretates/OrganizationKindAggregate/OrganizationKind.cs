using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate.Enumerations;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationKindAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationKindAggregate;

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
