using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxeTrace.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Internal.Operative.Clients;

public sealed class StrategicAxeTraceQueryApiClient
{
    private readonly IHttpClientProviderPort httpClientProvider;

    public StrategicAxeTraceQueryApiClient(IHttpClientProviderPort httpClientProvider)
    {
        this.httpClientProvider = httpClientProvider;
    }

    public Task<StrategicAxeTraceDetailDtoModel[]> GetForTargetAsync(int targetId)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<StrategicAxeTraceDetailDtoModel[]>($"api/strategicaxetraces/target/{targetId}");
    }
}