using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Abstracts;

public abstract class AbstractQueryApiClient<TId, TBasicDtoModel, TDetailDtoModel> : IQueryApiClient<TId, TBasicDtoModel, TDetailDtoModel>
{
    protected readonly IHttpClientProviderPort httpClientProvider;

    protected AbstractQueryApiClient(IHttpClientProviderPort httpClientProvider)
    {
        this.httpClientProvider = httpClientProvider;
    }

    protected abstract string GetUseCaseBaseUriSegment();

    public Task<int> CountAsync()
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<int>($"{GetUseCaseBaseUriSegment()}/count");
    }

    public Task<TBasicDtoModel[]> GetAllAsync()
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<TBasicDtoModel[]>(GetUseCaseBaseUriSegment());
    }

    public Task<TDetailDtoModel> GetAsync(TId id)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<TDetailDtoModel>($"{GetUseCaseBaseUriSegment()}/{id}");
    }

    public Task<PaginateResultModel<TBasicDtoModel>> GetPageAsync(int page, int limit)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<PaginateResultModel<TBasicDtoModel>>($"{GetUseCaseBaseUriSegment()}/page/{page}/limit/{limit}");
    }

    public Task<PaginateResultModel<TBasicDtoModel>> FilterPageAsync(int page, int limit, string parameter)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<PaginateResultModel<TBasicDtoModel>>($"{GetUseCaseBaseUriSegment()}/page/{page}/limit/{limit}/filter/{parameter}");
    }
}
