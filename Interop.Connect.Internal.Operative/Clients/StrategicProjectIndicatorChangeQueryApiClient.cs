using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Internal.Operative.Clients;

public sealed class StrategicProjectIndicatorChangeQueryApiClient
{
    private readonly IHttpClientProviderPort httpClientProvider;

    public StrategicProjectIndicatorChangeQueryApiClient(IHttpClientProviderPort httpClientProvider)
    {
        this.httpClientProvider = httpClientProvider;
    }

    public Task<IndicatorChangeDetailDtoModel[]> GetByProjectIndicatorAsync(Guid programId, Guid indicatorId)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<IndicatorChangeDetailDtoModel[]>($"api/strategicprojectindicatorchanges/by/program/{programId}/indicator/{indicatorId}");
    }

    public Task<IndicatorChangeDetailDtoModel[]> GetLastsByProjectAsync(Guid programId)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<IndicatorChangeDetailDtoModel[]>($"api/strategicprojectindicatorchanges/lasts/by/program/{programId}");
    }
}