using MOROPO.GEDET.CAM.Core.Common.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Bridges;

namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.Ports.Repository;

public interface IRolePermissionBridgeCommandRepositoryPort : IBridgeCommandRepositoryPort<RolePermissionBridge, Role, RoleId, Guid, Permission, PermissionId, string>
{
}
