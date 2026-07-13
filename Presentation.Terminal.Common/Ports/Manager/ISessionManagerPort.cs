using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Authentication.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Manager;

public interface ISessionManagerPort
{
    public AuthenticatedSessionDtoModel? CurrentSession { get; }

    public Task SignInAsync(string login, string password);

    public Task SignOutAsync();
}
