using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.EconomicActivityTrace.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Internal.Operative.Clients;

public sealed class EconomicActivityTraceQueryApiClient
{
    private readonly IHttpClientProviderPort httpClientProvider;

    public EconomicActivityTraceQueryApiClient(IHttpClientProviderPort httpClientProvider)
    {
        this.httpClientProvider = httpClientProvider;
    }

    public Task<EconomicActivityTraceDetailDtoModel[]> GetForTargetAsync(int targetId)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<EconomicActivityTraceDetailDtoModel[]>($"api/economicactivitytraces/target/{targetId}");
    }
}