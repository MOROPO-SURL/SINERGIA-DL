using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Authentication.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Authentication.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Ports.Manager.Adapters;

public class DefaultSessionManagerPortAdapter : ISessionManagerPort
{
    public AuthenticatedSessionDtoModel? CurrentSession { get; private set; }

    public async Task SignInAsync(string login, string password)
    {
        IHttpClientProviderPort httpClientProvider = IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>();

        var apiClient = new AuthenticationApiClient(httpClientProvider);

        CurrentSession = await apiClient.AuthenticateAsync(new AuthenticationRequestModel(login, password));

        httpClientProvider.Reset();
    }

    public Task SignOutAsync()
    {
        CurrentSession = null;

        return Task.CompletedTask;
    }
}

