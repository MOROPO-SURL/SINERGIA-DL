using MapsterMapper;
using MediatR;
using MOROPO.GEDET.CAM.Core.UseCases.Entitys.CQRS.Command.Remove;
using MOROPO.GEDET.CAM.Core.UseCases.Users.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate.Values;

namespace MOROPO.GEDET.CAM.Core.UseCases.Users.CQRS.Command.Remove;

internal sealed class UserRemoveCommandHandler : 
    AbstractRemoveCommandHandler<User, UserId, string, UserRemoveCommand>,
    IRequestHandler<UserRemoveCommand>
{
    public UserRemoveCommandHandler(IUserQueryRepositoryPort entityQueryRepository, IUserCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}
