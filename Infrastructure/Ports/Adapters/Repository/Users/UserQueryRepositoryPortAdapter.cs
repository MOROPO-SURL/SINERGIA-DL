using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UserAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UserAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.Users;

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