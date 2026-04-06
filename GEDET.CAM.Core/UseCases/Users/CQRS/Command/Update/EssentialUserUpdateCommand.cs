namespace MOROPO.GEDET.CAM.Core.UseCases.Users.CQRS.Command.Update;

public record EssentialUserUpdateCommand(string Id, string Name, string? LastName = null) : MediatR.IRequest<DTOs.UserDetailDto>;