using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProjectTrace.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Internal.Operative.Clients;

public sealed class StrategicProjectTraceQueryApiClient
{
    private readonly IHttpClientProviderPort httpClientProvider;

    public StrategicProjectTraceQueryApiClient(IHttpClientProviderPort httpClientProvider)
    {
        this.httpClientProvider = httpClientProvider;
    }

    public Task<StrategicProjectTraceDetailDtoModel[]> GetForTargetAsync(Guid targetId)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<StrategicProjectTraceDetailDtoModel[]>($"api/strategicprojecttraces/target/{targetId}");
    }
}