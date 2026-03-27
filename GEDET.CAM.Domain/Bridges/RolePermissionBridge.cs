using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Bridges;

public class RolePermissionBridge : IBridge<Role, RoleId, Permission, PermissionId>
{
    private RolePermissionBridge() { }

    public RolePermissionBridge(RoleId mainId, Role main, PermissionId linkedId, Permission linked)
    {
        MainId = mainId;
        Main = main;
        LinkedId = linkedId;
        Linked = linked;
    }

    public RoleId MainId { get; set; }
    public Role Main { get; set; } = null!;

    public PermissionId LinkedId { get; set; }
    public Permission Linked { get; set; } = null!;
}
