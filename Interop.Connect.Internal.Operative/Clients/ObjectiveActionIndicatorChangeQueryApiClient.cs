using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Internal.Operative.Clients;

public sealed class ObjectiveActionIndicatorChangeQueryApiClient
{
    private readonly IHttpClientProviderPort httpClientProvider;

    public ObjectiveActionIndicatorChangeQueryApiClient(IHttpClientProviderPort httpClientProvider)
    {
        this.httpClientProvider = httpClientProvider;
    }

    public Task<IndicatorChangeDetailDtoModel[]> GetByObjectiveActionIndicatorAsync(Guid objectiveId, Guid actionId, Guid indicatorId)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<IndicatorChangeDetailDtoModel[]>($"api/objectiveactionindicatorchanges/by/objective/{objectiveId}/action/{actionId}/indicator/{indicatorId}");
    }

    public Task<IndicatorChangeDetailDtoModel[]> GetLastsByObjectiveAsync(Guid objectiveId)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<IndicatorChangeDetailDtoModel[]>($"api/objectiveactionindicatorchanges/lasts/by/objective/{objectiveId}");
    }
}