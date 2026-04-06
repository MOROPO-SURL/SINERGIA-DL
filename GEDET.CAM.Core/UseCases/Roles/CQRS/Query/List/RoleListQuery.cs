using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate;
using System.Linq.Expressions;

namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Query.List;

public record RoleListQuery(Expression<Func<Role, bool>>? Criteria = null) : MediatR.IRequest<DTOs.RoleBasicDto[]>;
