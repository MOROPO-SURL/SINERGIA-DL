using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;

public sealed class NaturalOwnedPDLDevelopmentActorProfilesQueryApiClient
{
    private readonly IHttpClientProviderPort httpClientProvider;

    public NaturalOwnedPDLDevelopmentActorProfilesQueryApiClient(IHttpClientProviderPort httpClientProvider)
    {
        this.httpClientProvider = httpClientProvider;
    }

    public Task<NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel[]> GetAllAsync()
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel[]>("api/naturalownedpdldevelopmentactorprofiles");
    }

    public Task<DevelopmentActorProfileBasicDtoModel> GetBasicByOwnerAsync(Guid id)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<DevelopmentActorProfileBasicDtoModel>($"api/naturalownedpdldevelopmentactorprofiles/by/owner/{id}");
    }

    public Task<NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel> GetDetailByOwnerAsync(Guid id)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel>($"api/naturalownedpdldevelopmentactorprofiles/by/owner/{id}/detail");
    }
}
