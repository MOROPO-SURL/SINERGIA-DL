using MediatR;
using MOROPO.GEDET.CAM.Core.UseCases.Authentication.Ports.Service;

namespace MOROPO.GEDET.CAM.Core.UseCases.Authentication.CQRS.Command;

internal class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, DTOs.AuthenticationIdentityDto>
{
    private readonly IIdentityAuthenticationServicePort identityAuthenticationService;

    public AuthenticateCommandHandler(IIdentityAuthenticationServicePort identityAuthenticationService)
    {
        this.identityAuthenticationService = identityAuthenticationService;
    }

    public async Task<DTOs.AuthenticationIdentityDto> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
    {
        return await identityAuthenticationService.AuthenticateIdentityAsync(request.Key, request.Password, request.AuthenticationType);
    }
}