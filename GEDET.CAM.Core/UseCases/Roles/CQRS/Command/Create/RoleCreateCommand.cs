using MOROPO.GEDET.CAM.Core.UseCases.Roles.DTOs;

namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Command.Create;

public record RoleCreateCommand(string Name, string[] Permissions, string? Description) : MediatR.IRequest<RoleDetailDto>;
