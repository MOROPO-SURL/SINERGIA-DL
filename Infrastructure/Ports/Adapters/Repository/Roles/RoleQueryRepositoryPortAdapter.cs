using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Roles.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.RoleAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.RoleAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.Roles;

internal sealed class RoleQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<Role, RoleId, Guid>, IRoleQueryRepositoryPort
{
    public RoleQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<Role> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.PermissionBridges).ThenInclude(bridge => bridge.Linked);
    }
}