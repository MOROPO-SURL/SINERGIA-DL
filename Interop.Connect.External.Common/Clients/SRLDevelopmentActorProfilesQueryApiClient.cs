using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.External.Common.Clients;

public sealed class SRLDevelopmentActorProfilesQueryApiClient
{
    private readonly IHttpClientProviderPort httpClientProvider;

    public SRLDevelopmentActorProfilesQueryApiClient(IHttpClientProviderPort httpClientProvider)
    {
        this.httpClientProvider = httpClientProvider;
    }

    public Task<SRLDevelopmentActorProfileBasicDtoModel> GetBasicByOwnerAsync(Guid id)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<SRLDevelopmentActorProfileBasicDtoModel>($"api/srldevelopmentactorprofiles/by/owner/{id}");
    }

    public Task<SRLDevelopmentActorProfileDetailDtoModel> GetDetailByOwnerAsync(Guid id)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<SRLDevelopmentActorProfileDetailDtoModel>($"api/srldevelopmentactorprofiles/by/owner/{id}/detail");
    }
}
