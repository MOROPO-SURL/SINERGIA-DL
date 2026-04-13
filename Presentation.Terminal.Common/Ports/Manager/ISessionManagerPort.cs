using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Authentication.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Ports.Manager;

public interface ISessionManagerPort
{
    public AuthenticatedSessionModel? CurrentSession { get; }

    public Task SignInAsync(string login, string password);

    public Task SignOutAsync();
}
