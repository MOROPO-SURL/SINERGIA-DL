using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicLineTrace.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Internal.Operative.Clients;

public sealed class StrategicLineTraceQueryApiClient
{
    private readonly IHttpClientProviderPort httpClientProvider;

    public StrategicLineTraceQueryApiClient(IHttpClientProviderPort httpClientProvider)
    {
        this.httpClientProvider = httpClientProvider;
    }

    public Task<StrategicLineTraceDetailDtoModel[]> GetForTargetAsync(Guid targetId)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<StrategicLineTraceDetailDtoModel[]>($"api/strategiclinetraces/target/{targetId}");
    }
}