using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Bridges;

public class UserRoleBridge : IBridge<User, UserId, string, Role, RoleId, Guid>, IPersistenceSignable
{
    private UserRoleBridge() { }

    public UserRoleBridge(UserId mainId, RoleId linkedId)
    {
        MainId = mainId;
        LinkedId = linkedId;
    }

    public UserId MainId { get; set; }
    public User? Main { get; set; }

    public RoleId LinkedId { get; set; }
    public Role? Linked { get; set; } = null!;

    public string Signature { get; set; } = null!;

    public object GetSignableEntityModel()
    {
        return new { MainId, LinkedId };
    }
}