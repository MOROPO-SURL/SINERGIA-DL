using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.DevelopmentActorProfile.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;

public sealed class SRLDevelopmentActorProfilesQueryApiClient
{
    private readonly IHttpClientProviderPort httpClientProvider;

    public SRLDevelopmentActorProfilesQueryApiClient(IHttpClientProviderPort httpClientProvider)
    {
        this.httpClientProvider = httpClientProvider;
    }

    public Task<SRLDevelopmentActorProfileDetailDtoModel[]> GetAllAsync()
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<SRLDevelopmentActorProfileDetailDtoModel[]>("api/srldevelopmentactorprofiles");
    }

    public Task<DevelopmentActorProfileBasicDtoModel> GetBasicByOwnerAsync(Guid id)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<DevelopmentActorProfileBasicDtoModel>($"api/srldevelopmentactorprofiles/by/owner/{id}");
    }

    public Task<SRLDevelopmentActorProfileDetailDtoModel> GetDetailByOwnerAsync(Guid id)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<SRLDevelopmentActorProfileDetailDtoModel>($"api/srldevelopmentactorprofiles/by/owner/{id}/detail");
    }
}
