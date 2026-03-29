using MediatR;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.DTOs;

namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Query.Detail;

public record RoleDetailQuery(Guid Id) : IRequest<RoleDetailDto>;
