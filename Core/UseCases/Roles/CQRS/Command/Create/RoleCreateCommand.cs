using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Roles.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Roles.CQRS.Command.Create;

public record RoleCreateCommand(string Name, string[] Permissions, string? Description) : MediatR.IRequest<RoleDetailDto>;