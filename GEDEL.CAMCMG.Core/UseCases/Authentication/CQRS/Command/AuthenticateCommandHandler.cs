using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Authentication.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Authentication.Ports.Service;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Authentication.CQRS.Command;

internal class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, AuthenticationIdentityDto>
{
    private readonly IIdentityAuthenticationServicePort identityAuthenticationService;

    public AuthenticateCommandHandler(IIdentityAuthenticationServicePort identityAuthenticationService)
    {
        this.identityAuthenticationService = identityAuthenticationService;
    }

    public async Task<AuthenticationIdentityDto> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
    {
        return await identityAuthenticationService.AuthenticateIdentityAsync(request.Key, request.Password, request.AuthenticationType);
    }
}