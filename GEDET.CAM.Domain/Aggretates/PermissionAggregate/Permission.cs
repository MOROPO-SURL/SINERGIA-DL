using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Contract;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate;

public class Permission : AbstractEntity<PermissionId>, IAggregateRoot
{
    public Permission(PermissionId id, string family, string description) : base(id)
    {
        Family = family;
        Description = description;
    }

    public string? Family { get; set; }

    public string? Description { get; set; }
}

