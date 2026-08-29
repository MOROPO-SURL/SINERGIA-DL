using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.RoleAggregate;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Roles.CQRS.Query.List;

public record RoleListQuery(Expression<Func<Role, bool>>? Criteria = null) : MediatR.IRequest<DTOs.RoleBasicDto[]>;
