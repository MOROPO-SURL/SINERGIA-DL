using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Contract;
using MOROPO.GEDET.CAM.Domain.Common.Ports.Service;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate;

public class User : AbstractAuditableEntity<UserId>, IAggregateRoot, IEnableableEntity<UserId>, IPersistenceSignable
{
    public User(IDataIntegrityServicePort dataIntegrityService, UserId id, bool enabled, string password, bool passwordChangeRequired, bool hasFullAccess, int failAuthenticationCount, string name, string? lastName, DateTime? lastSessionDate, ImageAggregate.Image? image, ImageAggregate.ImageId? imageId, UserRoleBridge[] roleBridges) : base(id)
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
        Signature = dataIntegrityService.GetEntitySignature(this);
    }

    public bool Enabled { get; set; }

    public string Password { get; set; }

    public bool PasswordChangeRequired { get; set; }

    public bool HasFullAccess { get; set; }

    public DateTime? LastSessionDate { get; set; }

    public int FailAuthenticationCount { get; set; }

    public string Name { get; set; }

    public string? LastName { get; set; }

    public ImageAggregate.Image? Image { get; set; }
    public ImageAggregate.ImageId? ImageId { get; set; }

    public string Signature { get; set; }

    public List<UserRoleBridge> RoleBridges { get; set; }

    public object GetSignableEntityModel()
    {
        return new { Id, Enabled, HasFullAccess, Password };
    }
}
