namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Command.Remove;

public record RoleRemoveCommand(Guid Id) : MediatR.IRequest;