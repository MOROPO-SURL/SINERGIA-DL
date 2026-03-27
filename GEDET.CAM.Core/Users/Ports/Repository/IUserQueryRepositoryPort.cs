using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate.Values;

namespace MOROPO.GEDET.CAM.Core.Users.Ports.Repository;

public interface IUserQueryRepositoryPort : Common.Ports.Repository.IEntityQueryRepositoryPort<User, UserId>
{
}
