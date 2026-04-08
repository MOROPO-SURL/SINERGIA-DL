namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.CQRS.Command.Remove;

public record RoleRemoveCommand(Guid Id) : MediatR.IRequest;