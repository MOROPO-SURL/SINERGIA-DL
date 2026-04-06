using MOROPO.GEDET.CAM.Core.UseCases.Roles.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate.Values;
using MOROPO.GEDET.CAM.Infrastructure.Persistence.EF;
using MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.GEDET.CAM.Infrastructure.Ports.Adapters.Repository.Roles;

internal sealed class RoleCommandRepositoryPortAdapter : AbstractEntityCommandRepositoryPortAdapter<Role, RoleId, Guid>, IRoleCommandRepositoryPort
{
    public RoleCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}