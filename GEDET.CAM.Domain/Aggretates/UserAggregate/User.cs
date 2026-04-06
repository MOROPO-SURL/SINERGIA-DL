using MOROPO.GEDET.CAM.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Bridges;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate;

public class User : AbstractAuditableEntity<UserId, string>, IAggregateRoot<UserId, string>, IEnableableEntity<UserId, string>, IPersistenceSignable
{
    private User() : base(new UserId(string.Empty)) { }

    public User(UserId id, bool isEnabled, string password, string name, string? lastName = null, bool isPasswordChangeRequired = true, bool hasFullAccess = false) : base(id)
    {
        IsEnabled = isEnabled;
        Password = password;
        IsPasswordChangeRequired = isPasswordChangeRequired;
        HasFullAccess = hasFullAccess;
        Name = name;
        LastName = lastName;
    }

    public bool IsEnabled { get; set; }

    public string Password { get; set; } = null!;

    public bool IsPasswordChangeRequired { get; set; }

    public bool HasFullAccess { get; set; }

    public DateTime? LastSessionDate { get; set; }

    public int FailAuthenticationCount { get; set; }

    public string Name { get; set; } = null!;

    public string? LastName { get; set; }

    public ImageAggregate.Image? Image { get; set; }
    public ImageId? ImageId { get; set; }

    public string Signature { get; set; } = null!;

    public List<UserRoleBridge> RoleBridges { get; set; } = [];

    public object GetSignableEntityModel()
    {
        return new { Id, IsEnabled, HasFullAccess, Password };
    }
}