using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Authentication.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Authentication.Ports.Service;

public interface IIdentityAuthenticationServicePort
{
    Task<AuthenticationIdentityDto> AuthenticateIdentityAsync(string username, string password, string authenticationType);
}