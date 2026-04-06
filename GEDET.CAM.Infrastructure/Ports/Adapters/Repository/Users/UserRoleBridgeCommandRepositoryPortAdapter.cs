using MOROPO.GEDET.CAM.Core.UseCases.Users.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Bridges;
using MOROPO.GEDET.CAM.Infrastructure.Persistence.EF;
using MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.GEDET.CAM.Infrastructure.Ports.Adapters.Repository.Users;

internal sealed class UserRoleBridgeCommandRepositoryPortAdapter : AbstractBridgeCommandRepositoryPortAdapter<UserRoleBridge, User, UserId, string, Role, RoleId, Guid>, IUserRoleBridgeCommandRepositoryPort
{
    public UserRoleBridgeCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}