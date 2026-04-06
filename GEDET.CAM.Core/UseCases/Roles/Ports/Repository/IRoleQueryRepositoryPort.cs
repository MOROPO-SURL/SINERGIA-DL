using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate.Values;

namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.Ports.Repository;

public interface IRoleQueryRepositoryPort : Common.Ports.Repository.IEntityQueryRepositoryPort<Role, RoleId, Guid>
{
}