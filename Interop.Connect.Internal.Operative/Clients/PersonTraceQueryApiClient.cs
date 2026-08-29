using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.PersonTrace.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Internal.Operative.Clients;

public sealed class PersonTraceQueryApiClient
{
    private readonly IHttpClientProviderPort httpClientProvider;

    public PersonTraceQueryApiClient(IHttpClientProviderPort httpClientProvider)
    {
        this.httpClientProvider = httpClientProvider;
    }

    public Task<PersonTraceDetailDtoModel[]> GetForTargetAsync(Guid targetId)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<PersonTraceDetailDtoModel[]>($"api/persontraces/target/{targetId}");
    }
}