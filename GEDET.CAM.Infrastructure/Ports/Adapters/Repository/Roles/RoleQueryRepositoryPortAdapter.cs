using Microsoft.EntityFrameworkCore;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate.Values;
using MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.GEDET.CAM.Infrastructure.Ports.Adapters.Repository.Roles;

internal sealed class RoleQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<Role, RoleId, Guid>, IRoleQueryRepositoryPort
{
    public RoleQueryRepositoryPortAdapter(Persistence.EF.DefaultDbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<Role> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.PermissionBridges).ThenInclude(bridge => bridge.Linked);
    }
}