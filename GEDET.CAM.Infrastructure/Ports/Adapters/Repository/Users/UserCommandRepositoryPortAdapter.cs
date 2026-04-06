using MOROPO.GEDET.CAM.Core.UseCases.Users.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate.Values;
using MOROPO.GEDET.CAM.Infrastructure.Persistence.EF;
using MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.GEDET.CAM.Infrastructure.Ports.Adapters.Repository.Users;

internal sealed class UserCommandRepositoryPortAdapter : AbstractEntityCommandRepositoryPortAdapter<User, UserId, string>, IUserCommandRepositoryPort
{
    public UserCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}