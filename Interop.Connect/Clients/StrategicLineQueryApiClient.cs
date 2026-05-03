using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Abstracts;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;

public sealed class StrategicLineQueryApiClient
{
    private const string USE_CASE_BASE_URI_SEGMENT = "api/strategiclines";

    private readonly IHttpClientProviderPort httpClientProvider;

    public StrategicLineQueryApiClient(IHttpClientProviderPort httpClientProvider)
    {
        this.httpClientProvider = httpClientProvider;
    }

    public Task<int> CountAsync()
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<int>($"{USE_CASE_BASE_URI_SEGMENT}/count");
    }

    public Task<StrategicLineDetailDtoModel[]> GetAllAsync()
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<StrategicLineDetailDtoModel[]>(USE_CASE_BASE_URI_SEGMENT);
    }

    public Task<StrategicLineDetailDtoModel> GetAsync(int id, int axeId)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<StrategicLineDetailDtoModel>($"{USE_CASE_BASE_URI_SEGMENT}/{id}/axe/{axeId}");
    }

    public Task<PaginateResultModel<StrategicLineBasicDtoModel>> GetPageAsync(int page, int limit)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<PaginateResultModel<StrategicLineBasicDtoModel>>($"{USE_CASE_BASE_URI_SEGMENT}/page/{page}/limit/{limit}");
    }

    public Task<PaginateResultModel<StrategicLineBasicDtoModel>> FilterPageAsync(int page, int limit, string parameter)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<PaginateResultModel<StrategicLineBasicDtoModel>>($"{USE_CASE_BASE_URI_SEGMENT}/page/{page}/limit/{limit}/filter/{parameter}");
    }
}