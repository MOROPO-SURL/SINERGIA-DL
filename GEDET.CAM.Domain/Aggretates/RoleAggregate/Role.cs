using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Contract;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate;

public class Role : AbstractAuditableEntity<RoleId>, IAggregateRoot, INamedEntity<RoleId>
{
    public Role(RoleId id, string name, string description, RolePermissionBridge[] permissionBridges) : base(id)
    {
        Name = name;
        Description = description;
        PermissionBridges = [.. permissionBridges];
    }

    public string Name { get; set; }

    public string Description { get; set; }

    public List<RolePermissionBridge> PermissionBridges { get; set; }
}
