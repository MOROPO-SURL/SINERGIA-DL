namespace MOROPO.GEDET.CAM.Core.UseCases.Authentication.CQRS.Command;

public record AuthenticateCommand(string Key, string Password, string AuthenticationType) : MediatR.IRequest<DTOs.AuthenticationIdentityDto>;
