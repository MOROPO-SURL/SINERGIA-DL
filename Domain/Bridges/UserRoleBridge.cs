using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.RoleAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.RoleAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UserAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UserAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Bridges;

public class UserRoleBridge : IBridge<User, UserId, string, Role, RoleId, Guid>, IPersistenceSignable
{
    private UserRoleBridge() { }

    public UserRoleBridge(UserId mainId, RoleId linkedId, User? main = null, Role? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Main = main;
        Linked = linked;
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