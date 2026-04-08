using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.RoleAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.RoleAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UserAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UserAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Users;

internal sealed class UserRoleBridgeCommandRepositoryPortAdapter : AbstractBridgeCommandRepositoryPortAdapter<UserRoleBridge, User, UserId, string, Role, RoleId, Guid>, IUserRoleBridgeCommandRepositoryPort
{
    public UserRoleBridgeCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}