using Microsoft.EntityFrameworkCore;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate.Values;
using MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.GEDET.CAM.Infrastructure.Adapters.Repository;

internal class RoleRepository : AbstractQueryRepositoryAdapter<Role, RoleId>, Core.Roles.Ports.Repository.IRoleQueryRepositoryPort
{
    public RoleRepository(Persistence.EF.DefaultDbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<Role> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.PermissionBridges).ThenInclude(bridge => bridge.Linked);
    }
}
