using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.RoleAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Bridges;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.RoleAggregate;

public class Role : AbstractAuditableEntity<RoleId, Guid>, IAggregateRoot<RoleId, Guid>, INamedEntity<RoleId, Guid>
{
    private Role() : base(default) { }

    public Role(RoleId id, string name, string? description = null) : base(id)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public List<RolePermissionBridge> PermissionBridges { get; set; } = [];
}