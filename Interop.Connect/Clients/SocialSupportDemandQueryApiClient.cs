using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients.Abstracts;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.SocialSupportDemand.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;

public sealed class SocialSupportDemandQueryApiClient : AbstractQueryApiClient<Guid, SocialSupportDemandBasicDtoModel, SocialSupportDemandDetailDtoModel>
{
    public SocialSupportDemandQueryApiClient(IHttpClientProviderPort httpClientProvider) : base(httpClientProvider)
    {
    }

    protected override string GetUseCaseBaseUriSegment() => "api/socialsupportdemands";

    public Task<PaginateResultModel<SocialSupportDemandBasicDtoModel>> GetCurrentsPageAsync(int page, int limit)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<PaginateResultModel<SocialSupportDemandBasicDtoModel>>($"{GetUseCaseBaseUriSegment()}/currents/page/{page}/limit/{limit}");
    }

    public Task<PaginateResultModel<SocialSupportDemandBasicDtoModel>> FilterCurrentsPageAsync(int page, int limit, string parameter)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<PaginateResultModel<SocialSupportDemandBasicDtoModel>>($"{GetUseCaseBaseUriSegment()}/currents/page/{page}/limit/{limit}/filter/{parameter}");
    }
}