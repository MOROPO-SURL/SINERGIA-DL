using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PermissionAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PermissionAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.RoleAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.RoleAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Bridges;

public class RolePermissionBridge : IBridge<Role, RoleId, Guid, Permission, PermissionId, string>
{
    private RolePermissionBridge() { }

    public RolePermissionBridge(RoleId mainId, PermissionId linkedId, Role? main = null, Permission? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Main = main;
        Linked = linked;
    }

    public RoleId MainId { get; set; }
    public Role? Main { get; set; }

    public PermissionId LinkedId { get; set; }
    public Permission? Linked { get; set; }
}