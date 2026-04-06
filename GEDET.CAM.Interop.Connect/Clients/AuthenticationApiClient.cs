using MOROPO.GEDET.CAM.Interop.Connect.Clients.Extensions;
using MOROPO.GEDET.CAM.Interop.Connect.Ports.Provider;
using MOROPO.GEDET.CAM.Interop.Contracts.Models.Authentication.CQRS.Command;
using MOROPO.GEDET.CAM.Interop.Contracts.Models.Authentication.DTOs;

namespace MOROPO.GEDET.CAM.Interop.Connect.Clients;

public sealed class AuthenticationApiClient
{
    protected readonly IHttpClientProviderPort httpClientProvider;

    protected AuthenticationApiClient(IHttpClientProviderPort httpClientProvider)
    {
        this.httpClientProvider = httpClientProvider;
    }

    public Task<AuthenticatedSessionModel> AuthenticateAsync(AuthenticationRequestModel model)
    {
        return httpClientProvider.GetHttpClient().SendPostAsync<AuthenticationRequestModel, AuthenticatedSessionModel>("api/auth", model);
    }
}