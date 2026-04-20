using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Authentication.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Authentication.CQRS.Command;

public record AuthenticateCommand(string Key, string Password, string AuthenticationType) : MediatR.IRequest<AuthenticationIdentityDto>;
