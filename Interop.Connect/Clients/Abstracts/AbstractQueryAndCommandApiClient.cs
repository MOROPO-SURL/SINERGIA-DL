using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Abstracts;

public abstract class AbstractQueryAndCommandApiClient<TId, TCreateRequestModel, TUpdateRequestModel, TBasicDtoModel, TDetailDtoModel> : AbstractQueryApiClient<TId, TBasicDtoModel, TDetailDtoModel>, ICommandApiClient<TId, TCreateRequestModel, TUpdateRequestModel, TDetailDtoModel>
{
    protected AbstractQueryAndCommandApiClient(IHttpClientProviderPort httpClientProvider) : base(httpClientProvider)
    {
    }

    public Task<TDetailDtoModel> AddAsync(TCreateRequestModel model)
    {
        return httpClientProvider.GetHttpClient().SendPostAsync<TCreateRequestModel, TDetailDtoModel>(GetUseCaseBaseUriSegment(), model);
    }

    public Task<TDetailDtoModel> UpdateAsync(TUpdateRequestModel model)
    {
        return httpClientProvider.GetHttpClient().SendPutAsync<TUpdateRequestModel, TDetailDtoModel>(GetUseCaseBaseUriSegment(), model);
    }

    public Task DeleteAsync(TId id)
    {
        return httpClientProvider.GetHttpClient().SendDeleteAsync($"{GetUseCaseBaseUriSegment()}/{id}");
    }
}