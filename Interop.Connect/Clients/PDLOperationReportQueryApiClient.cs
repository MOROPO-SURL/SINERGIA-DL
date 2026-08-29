using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.OperationReport.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;

public sealed class PDLOperationReportQueryApiClient
{
    private const string USECASE_BASE_URI_SEGMENT = "api/pdloperationreports";

    private readonly IHttpClientProviderPort httpClientProvider;

    public PDLOperationReportQueryApiClient(IHttpClientProviderPort httpClientProvider)
    {
        this.httpClientProvider = httpClientProvider;
    }

    public Task<PDLOperationReportDetailDtoModel> GetAsync(long id)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<PDLOperationReportDetailDtoModel>($"{USECASE_BASE_URI_SEGMENT}/{id}");
    }

    public Task<PaginateResultModel<PDLOperationReportBasicDtoModel>> GetPageAsync(int page, int limit)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<PaginateResultModel<PDLOperationReportBasicDtoModel>>($"{USECASE_BASE_URI_SEGMENT}/page/{page}/limit/{limit}");
    }

    public Task<PaginateResultModel<PDLOperationReportBasicDtoModel>> FilterPageAsync(int page, int limit, string parameter)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<PaginateResultModel<PDLOperationReportBasicDtoModel>>($"{USECASE_BASE_URI_SEGMENT}/page/{page}/limit/{limit}/filter/{parameter}");
    }

    public Task<PaginateResultModel<PDLOperationReportBasicDtoModel>> FilterPageByOwnerAsync(Guid ownerId, int page, int limit)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<PaginateResultModel<PDLOperationReportBasicDtoModel>>($"{USECASE_BASE_URI_SEGMENT}/owner/{ownerId}/page/{page}/limit/{limit}");
    }
}
