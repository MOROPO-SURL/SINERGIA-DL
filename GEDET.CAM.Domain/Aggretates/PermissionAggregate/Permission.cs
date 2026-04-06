using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate;

public class Permission : AbstractEntity<PermissionId, string>, IAggregateRoot<PermissionId, string>
{
    public Permission(PermissionId id, string? family = null, string? description = null) : base(id)
    {
        Family = family;
        Description = description;
    }

    public string? Family { get; set; }

    public string? Description { get; set; }
}