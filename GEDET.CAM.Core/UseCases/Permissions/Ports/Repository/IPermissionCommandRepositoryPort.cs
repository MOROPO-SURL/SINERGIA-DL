using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate.Values;

namespace MOROPO.GEDET.CAM.Core.UseCases.Permissions.Ports.Repository;

public interface IPermissionCommandRepositoryPort : Common.Ports.Repository.IEntityCommandRepositoryPort<Permission, PermissionId, string>
{
}