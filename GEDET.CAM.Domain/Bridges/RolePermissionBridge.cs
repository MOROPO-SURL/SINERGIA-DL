using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Bridges;

public class RolePermissionBridge : IBridge<Role, RoleId, Guid, Permission, PermissionId, string>
{
    private RolePermissionBridge() { }

    public RolePermissionBridge(RoleId mainId, PermissionId linkedId)
    {
        MainId = mainId;
        LinkedId = linkedId;
    }

    public RoleId MainId { get; set; }
    public Role? Main { get; set; }

    public PermissionId LinkedId { get; set; }
    public Permission? Linked { get; set; }
}