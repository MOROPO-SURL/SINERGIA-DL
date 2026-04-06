using MediatR;
using MOROPO.GEDET.CAM.Core.Common.Models;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Query.Paginate;
using MOROPO.GEDET.CAM.Core.UseCases.Users.DTOs;
using MOROPO.GEDET.CAM.Core.UseCases.Users.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate.Values;

namespace MOROPO.GEDET.CAM.Core.UseCases.Users.CQRS.Query.Paginate;

internal sealed class UserPaginateQueryHandler :
    AbstractPaginateQueryHandler<User, UserId, string, UserPaginateQuery, UserBasicDto>,
    IRequestHandler<UserPaginateQuery, PaginateQueryResultModel<UserBasicDto>>
{
    public UserPaginateQueryHandler(IUserQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}
