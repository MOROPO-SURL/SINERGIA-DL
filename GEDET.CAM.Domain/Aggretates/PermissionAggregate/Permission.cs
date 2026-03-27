using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate;

public class Permission : AbstractEntity<PermissionId>, IAggregateRoot<PermissionId>
{
    public Permission(PermissionId id, string family, string description) : base(id)
    {
        Family = family;
        Description = description;
    }

    public string? Family { get; set; }

    public string? Description { get; set; }
}

