using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Bridges;

public class UserRoleBridge : IBridge<User, UserId, Role, RoleId>
{
    private UserRoleBridge() { }

    public UserRoleBridge(UserId mainId, User main, RoleId linkedId, Role linked)
    {
        MainId = mainId;
        Main = main;
        LinkedId = linkedId;
        Linked = linked;
    }

    public UserId MainId { get; set; }
    public User Main { get; set; } = null!; 

    public RoleId LinkedId { get; set; }
    public Role Linked { get; set; } = null!;
}
