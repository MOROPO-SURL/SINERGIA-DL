using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicAxeTrace.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Internal.Operative.Clients;

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