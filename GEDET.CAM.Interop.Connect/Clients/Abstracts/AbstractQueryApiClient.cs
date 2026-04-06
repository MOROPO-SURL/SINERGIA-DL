using MOROPO.GEDET.CAM.Interop.Connect.Clients.Extensions;
using MOROPO.GEDET.CAM.Interop.Connect.Ports.Provider;
using MOROPO.GEDET.CAM.Interop.Contracts.Models.Common;

namespace MOROPO.GEDET.CAM.Interop.Connect.Clients.Abstracts;

public abstract class AbstractQueryApiClient<TId, TBasicDtoModel, TDetailDtoModel> : Interfaces.IQueryApiClient<TId, TBasicDtoModel, TDetailDtoModel>
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
        return httpClientProvider.GetHttpClient().SendGetAsync<PaginateResultModel<TBasicDtoModel>>($"{GetUseCaseBaseUriSegment()}/sheet/{page}/limit/{limit}");
    }
}
