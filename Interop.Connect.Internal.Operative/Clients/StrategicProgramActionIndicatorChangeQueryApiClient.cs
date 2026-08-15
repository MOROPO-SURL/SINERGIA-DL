using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Internal.Operative.Clients;

public sealed class StrategicProgramActionIndicatorChangeQueryApiClient
{
    private readonly IHttpClientProviderPort httpClientProvider;

    public StrategicProgramActionIndicatorChangeQueryApiClient(IHttpClientProviderPort httpClientProvider)
    {
        this.httpClientProvider = httpClientProvider;
    }

    public Task<IndicatorChangeDetailDtoModel[]> GetByProgramActionIndicatorAsync(Guid programId, Guid actionId, Guid indicatorId)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<IndicatorChangeDetailDtoModel[]>($"api/strategicprogramactionindicatorchanges/by/program/{programId}/action/{actionId}/indicator/{indicatorId}");
    }

    public Task<IndicatorChangeDetailDtoModel[]> GetLastsByProgramAsync(Guid programId)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<IndicatorChangeDetailDtoModel[]>($"api/strategicprogramactionindicatorchanges/lasts/by/program/{programId}");
    }
}
