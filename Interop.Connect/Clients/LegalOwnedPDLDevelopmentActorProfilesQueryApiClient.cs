using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;

public sealed class LegalOwnedPDLDevelopmentActorProfilesQueryApiClient
{
    private readonly IHttpClientProviderPort httpClientProvider;

    public LegalOwnedPDLDevelopmentActorProfilesQueryApiClient(IHttpClientProviderPort httpClientProvider)
    {
        this.httpClientProvider = httpClientProvider;
    }

    public Task<LegalOwnedPDLDevelopmentActorProfileDetailDtoModel[]> GetAllAsync()
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<LegalOwnedPDLDevelopmentActorProfileDetailDtoModel[]>("api/legalownedpdldevelopmentactorprofiles");
    }

    public Task<DevelopmentActorProfileBasicDtoModel> GetBasicByOwnerAsync(Guid id)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<DevelopmentActorProfileBasicDtoModel>($"api/legalownedpdldevelopmentactorprofiles/by/owner/{id}");
    }

    public Task<LegalOwnedPDLDevelopmentActorProfileDetailDtoModel> GetDetailByOwnerAsync(Guid id)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<LegalOwnedPDLDevelopmentActorProfileDetailDtoModel>($"api/legalownedpdldevelopmentactorprofiles/by/owner/{id}/detail");
    }
}
