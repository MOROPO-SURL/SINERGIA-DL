using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.RoleAggregate;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.CQRS.Query.Paginate;

public record RolePaginateQuery(int Page, int Limit, Expression<Func<Role, bool>>? Criteria = null) : MediatR.IRequest<PaginateQueryResultModel<DTOs.RoleBasicDto>>;