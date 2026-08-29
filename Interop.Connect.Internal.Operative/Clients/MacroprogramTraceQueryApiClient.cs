using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.MacroprogramTrace.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Internal.Operative.Clients;

public sealed class MacroprogramTraceQueryApiClient
{
    private readonly IHttpClientProviderPort httpClientProvider;

    public MacroprogramTraceQueryApiClient(IHttpClientProviderPort httpClientProvider)
    {
        this.httpClientProvider = httpClientProvider;
    }

    public Task<MacroprogramTraceDetailDtoModel[]> GetForTargetAsync(Guid targetId)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<MacroprogramTraceDetailDtoModel[]>($"api/macroprogramtraces/target/{targetId}");
    }
}