using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Authentication.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Authentication.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;

public sealed class AuthenticationApiClient
{
    private readonly IHttpClientProviderPort httpClientProvider;

    public AuthenticationApiClient(IHttpClientProviderPort httpClientProvider)
    {
        this.httpClientProvider = httpClientProvider;
    }

    public Task<AuthenticatedSessionDtoModel> AuthenticateAsync(AuthenticationRequestModel model)
    {
        return httpClientProvider.GetHttpClient().SendPostAsync<AuthenticationRequestModel, AuthenticatedSessionDtoModel>("api/auth", model);
    }
}