using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProjectIdeaTrace.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Internal.Operative.Clients;

public sealed class StrategicProjectIdeaTraceQueryApiClient
{
    private readonly IHttpClientProviderPort httpClientProvider;

    public StrategicProjectIdeaTraceQueryApiClient(IHttpClientProviderPort httpClientProvider)
    {
        this.httpClientProvider = httpClientProvider;
    }

    public Task<StrategicProjectIdeaTraceDetailDtoModel[]> GetForTargetAsync(Guid targetId)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<StrategicProjectIdeaTraceDetailDtoModel[]>($"api/strategicprojectideatraces/target/{targetId}");
    }
}