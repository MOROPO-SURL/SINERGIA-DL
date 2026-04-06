using MapsterMapper;
using MediatR;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Query.Detail;
using MOROPO.GEDET.CAM.Core.UseCases.Users.DTOs;
using MOROPO.GEDET.CAM.Core.UseCases.Users.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate.Values;

namespace MOROPO.GEDET.CAM.Core.UseCases.Users.CQRS.Query.Detail;

internal sealed class UserDetailQueryHandler : 
    AbstractDetailQueryHandler<User, UserId, string, UserDetailQuery, UserDetailDto>,
    IRequestHandler<UserDetailQuery, UserDetailDto>
{
    public UserDetailQueryHandler(IUserQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}