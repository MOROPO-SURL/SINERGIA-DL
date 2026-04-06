namespace MOROPO.GEDET.CAM.Core.UseCases.Authentication.Ports.Service;

public interface IIdentityAuthenticationServicePort
{
    Task<DTOs.AuthenticationIdentityDto> AuthenticateIdentityAsync(string username, string password, string authenticationType);
}