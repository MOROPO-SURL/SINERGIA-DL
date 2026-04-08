using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.RoleAggregate;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.CQRS.Query.List;

public record RoleListQuery(Expression<Func<Role, bool>>? Criteria = null) : MediatR.IRequest<DTOs.RoleBasicDto[]>;
