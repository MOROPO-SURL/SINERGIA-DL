using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients.Abstracts;

public abstract class AbstractArchivableCommandApiClient<TId, TCreateRequestModel, TUpdateRequestModel, TDetailDtoModel> : AbstractCommandApiClient<TId, TCreateRequestModel, TUpdateRequestModel, TDetailDtoModel>
{
    protected AbstractArchivableCommandApiClient(IHttpClientProviderPort httpClientProvider) : base(httpClientProvider)
    {
    }

    public Task ArchiveAsync(TId id)
    {
        return httpClientProvider.GetHttpClient().SendPatchAsync($"{GetUseCaseBaseUriSegment()}/{id}/archive");
    }
}
