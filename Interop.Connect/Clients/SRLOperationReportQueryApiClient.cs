using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.OperationReport.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;

public sealed class SRLOperationReportQueryApiClient
{
    private const string USECASE_BASE_URI_SEGMENT = "api/srloperationreports";

    private readonly IHttpClientProviderPort httpClientProvider;

    public SRLOperationReportQueryApiClient(IHttpClientProviderPort httpClientProvider)
    {
        this.httpClientProvider = httpClientProvider;
    }

    public Task<SRLOperationReportDetailDtoModel> GetAsync(long id)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<SRLOperationReportDetailDtoModel>($"{USECASE_BASE_URI_SEGMENT}/{id}");
    }

    public Task<PaginateResultModel<SRLOperationReportBasicDtoModel>> GetPageAsync(int page, int limit)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<PaginateResultModel<SRLOperationReportBasicDtoModel>>($"{USECASE_BASE_URI_SEGMENT}/page/{page}/limit/{limit}");
    }

    public Task<PaginateResultModel<SRLOperationReportBasicDtoModel>> FilterPageAsync(int page, int limit, string parameter)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<PaginateResultModel<SRLOperationReportBasicDtoModel>>($"{USECASE_BASE_URI_SEGMENT}/page/{page}/limit/{limit}/filter/{parameter}");
    }

    public Task<PaginateResultModel<SRLOperationReportBasicDtoModel>> FilterPageByOwnerAsync(Guid ownerId, int page, int limit)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<PaginateResultModel<SRLOperationReportBasicDtoModel>>($"{USECASE_BASE_URI_SEGMENT}/owner/{ownerId}/page/{page}/limit/{limit}");
    }
}
