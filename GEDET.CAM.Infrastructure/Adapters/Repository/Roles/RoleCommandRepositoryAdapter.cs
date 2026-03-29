using MOROPO.GEDET.CAM.Core.UseCases.Roles.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate.Values;
using MOROPO.GEDET.CAM.Infrastructure.Persistence.EF;
using MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.GEDET.CAM.Infrastructure.Adapters.Repository.Roles;

internal class RoleCommandRepositoryAdapter : AbstractCommandRepositoryAdapter<Role, RoleId>, IRoleCommandRepositoryPort
{
    public RoleCommandRepositoryAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}
