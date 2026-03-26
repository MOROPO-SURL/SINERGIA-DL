using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Contract;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate;

public class UserRoleBridge : IBridge<User, UserId, RoleAggregate.Role, RoleAggregate.RoleId>
{
    public UserRoleBridge(UserId mainId, User main, RoleAggregate.RoleId linkedId, RoleAggregate.Role linked)
    {
        MainId = mainId;
        Main = main;
        LinkedId = linkedId;
        Linked = linked;
    }

    public UserId MainId { get; set; }
    public User Main { get; set; }

    public RoleAggregate.RoleId LinkedId { get; set; }
    public RoleAggregate.Role Linked { get; set; }
}
