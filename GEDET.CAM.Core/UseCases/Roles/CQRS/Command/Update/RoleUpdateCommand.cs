using MOROPO.GEDET.CAM.Core.UseCases.Roles.DTOs;

namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Command.Update;

public record RoleUpdateCommand(Guid Id, string Name, string[] Permissions, string? Description) : MediatR.IRequest<RoleDetailDto>
{
}