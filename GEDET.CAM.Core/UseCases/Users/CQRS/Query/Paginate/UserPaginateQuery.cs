using MOROPO.GEDET.CAM.Core.Common.CQRS.Query.Interfaces;
using MOROPO.GEDET.CAM.Core.UseCases.Users.DTOs;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.GEDET.CAM.Core.UseCases.Users.CQRS.Query.Paginate;

public record UserPaginateQuery(int Page, int Limit, Expression<Func<User, bool>>? Criteria = null) : IPaginateQuery<User, UserId, string, UserBasicDto>;