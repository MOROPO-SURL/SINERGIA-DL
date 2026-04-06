using MOROPO.GEDET.CAM.Core.Common.Models;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate;
using System.Linq.Expressions;

namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Query.Paginate;

public record RolePaginateQuery(int Page, int Limit, Expression<Func<Role, bool>>? Criteria = null) : MediatR.IRequest<PaginateQueryResultModel<DTOs.RoleBasicDto>>;