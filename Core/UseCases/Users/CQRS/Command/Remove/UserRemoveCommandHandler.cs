using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UserAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UserAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.CQRS.Command.Remove;

internal sealed class UserRemoveCommandHandler :
    AbstractRemoveCommandHandler<User, UserId, string, UserRemoveCommand>,
    IRequestHandler<UserRemoveCommand>
{
    public UserRemoveCommandHandler(IUserCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, mapper)
    {
    }
}