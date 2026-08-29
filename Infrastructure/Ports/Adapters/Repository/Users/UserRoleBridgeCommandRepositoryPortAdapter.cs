using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.RoleAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.RoleAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UserAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UserAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Bridges;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.Users;

internal sealed class UserRoleBridgeCommandRepositoryPortAdapter : AbstractBridgeCommandRepositoryPortAdapter<UserRoleBridge, User, UserId, string, Role, RoleId, Guid>, IUserRoleBridgeCommandRepositoryPort
{
    public UserRoleBridgeCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}