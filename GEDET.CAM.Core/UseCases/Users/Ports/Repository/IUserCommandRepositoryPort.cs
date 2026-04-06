using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate.Values;

namespace MOROPO.GEDET.CAM.Core.UseCases.Users.Ports.Repository;

public interface IUserCommandRepositoryPort : Common.Ports.Repository.IEntityCommandRepositoryPort<User, UserId, string>
{
}