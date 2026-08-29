using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.RoleAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.RoleAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Roles.CQRS.Query.Paginate;

public record RolePaginateQuery(int Page, int Limit, Expression<Func<Role, bool>>? Criteria = null) : IPaginateQuery<Role, RoleId, Guid, DTOs.RoleBasicDto>, MediatR.IRequest<PaginateQueryResultModel<DTOs.RoleBasicDto>>;