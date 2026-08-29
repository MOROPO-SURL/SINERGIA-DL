using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Authentication.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Authentication.CQRS.Command;

public record AuthenticateCommand(string Key, string Password, string AuthenticationType) : MediatR.IRequest<AuthenticationIdentityDto>;
