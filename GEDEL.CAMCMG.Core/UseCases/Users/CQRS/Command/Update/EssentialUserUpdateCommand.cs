namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.CQRS.Command.Update;

public record EssentialUserUpdateCommand(string Id, string Name, string? LastName = null) : MediatR.IRequest<DTOs.UserDetailDto>;