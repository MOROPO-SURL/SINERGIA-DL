namespace MOROPO.GEDET.CAM.Core.UseCases.Users.CQRS.Command.Update;

public record PasswordUserUpdateCommand(string Id, string Password) : MediatR.IRequest;
