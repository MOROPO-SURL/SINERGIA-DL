using Microsoft.EntityFrameworkCore;
using MOROPO.GEDET.CAM.Core.UseCases.Users.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate.Values;
using MOROPO.GEDET.CAM.Infrastructure.Persistence.EF;
using MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.GEDET.CAM.Infrastructure.Ports.Adapters.Repository.Users;

internal sealed class UserQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<User, UserId, string>, IUserQueryRepositoryPort
{
    public UserQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<User> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .AsSplitQuery()
            .Include(entity => entity.RoleBridges).ThenInclude(bridge => bridge.Linked);
    }
}