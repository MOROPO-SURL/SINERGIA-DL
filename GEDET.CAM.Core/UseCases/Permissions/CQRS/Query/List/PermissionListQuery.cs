using MOROPO.GEDET.CAM.Core.Common.CQRS.Query.Interfaces;
using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.GEDET.CAM.Core.UseCases.Permissions.CQRS.Query.List;

public record PermissionListQuery(Expression<Func<Permission, bool>>? Criteria = null) : IListQuery<Permission, PermissionId, string, DTOs.PermissionDetailDto>;