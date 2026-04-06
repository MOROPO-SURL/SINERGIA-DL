using MOROPO.GEDET.CAM.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.TerritoryPotentialAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Bridges;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate;

public class User : AbstractAuditableEntity<UserId>, IAggregateRoot<UserId>, IEnableableEntity<UserId>, IPersistenceSignable
{
    private User() : base(new UserId(default)) { }

    public User(UserId id, bool enabled, string password, bool passwordChangeRequired, bool hasFullAccess, int failAuthenticationCount, string signature, string name, string? lastName, DateTime? lastSessionDate, ImageAggregate.Image? image, ImageId? imageId, UserRoleBridge[] roleBridges) : base(id)
    {
        Enabled = enabled;
        Password = password;
        PasswordChangeRequired = passwordChangeRequired;
        HasFullAccess = hasFullAccess;
        LastSessionDate = lastSessionDate;
        FailAuthenticationCount = failAuthenticationCount;
        Name = name;
        LastName = lastName;
        Image = image;
        ImageId = imageId;
        RoleBridges = [.. roleBridges];
        Signature = signature;
    }

    public bool Enabled { get; set; }

    public string Password { get; set; } = null!;

    public bool PasswordChangeRequired { get; set; }

    public bool HasFullAccess { get; set; }

    public DateTime? LastSessionDate { get; set; }

    public int FailAuthenticationCount { get; set; }

    public string Name { get; set; } = null!;

    public string? LastName { get; set; }

    public ImageAggregate.Image? Image { get; set; }
    public ImageId? ImageId { get; set; }

    public string Signature { get; set; } = null!;

    public List<UserRoleBridge> RoleBridges { get; set; } = null!;

    public object GetSignableEntityModel()
    {
        return new { Id, Enabled, HasFullAccess, Password };
    }
}
