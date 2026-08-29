namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Roles.CQRS.Command.Remove;

public record RoleRemoveCommand(Guid Id) : MediatR.IRequest;