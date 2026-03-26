using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Contract;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate;

public class RolePermissionBridge : IBridge<Role, RoleId, PermissionAggregate.Permission, PermissionAggregate.PermissionId>
{
    public RolePermissionBridge(RoleId mainId, Role main, PermissionAggregate.PermissionId linkedId, PermissionAggregate.Permission linked)
    {
        MainId = mainId;
        Main = main;
        LinkedId = linkedId;
        Linked = linked;
    }

    public RoleId MainId { get; set; }
    public Role Main { get; set; }

    public PermissionAggregate.PermissionId LinkedId { get; set; }
    public PermissionAggregate.Permission Linked { get; set; }
}
