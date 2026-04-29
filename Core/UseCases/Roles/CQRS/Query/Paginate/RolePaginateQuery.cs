using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.RoleAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.RoleAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.CQRS.Query.Paginate;

public record RolePaginateQuery(int Page, int Limit, Expression<Func<Role, bool>>? Criteria = null) : IPaginateQuery<Role, RoleId, Guid, DTOs.RoleBasicDto>, MediatR.IRequest<PaginateQueryResultModel<DTOs.RoleBasicDto>>;