using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Authentication.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Authentication.Ports.Service;

public interface IIdentityAuthenticationServicePort
{
    Task<AuthenticationIdentityDto> AuthenticateIdentityAsync(string username, string password, string authenticationType);
}