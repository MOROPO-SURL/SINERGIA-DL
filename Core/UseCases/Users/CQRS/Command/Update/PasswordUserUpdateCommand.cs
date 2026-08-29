namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.CQRS.Command.Update;

public record PasswordUserUpdateCommand(string Id, string Password, bool IsChangePasswordRequired = false) : MediatR.IRequest;
