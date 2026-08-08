using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialResponsabilityAction.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;

public sealed class SRLSocialResponsabilityActionQueryApiClient
{
    private const string USECASE_BASE_URI_SEGMENT = "api/srlsocialresponsabilityactions";

    private readonly IHttpClientProviderPort httpClientProvider;

    public SRLSocialResponsabilityActionQueryApiClient(IHttpClientProviderPort httpClientProvider)
    {
        this.httpClientProvider = httpClientProvider;
    }

    public Task<SRLSocialResponsabilityActionDetailDtoModel> GetAsync(Guid id)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<SRLSocialResponsabilityActionDetailDtoModel>($"{USECASE_BASE_URI_SEGMENT}/{id}");
    }

    public Task<PaginateResultModel<SRLSocialResponsabilityActionBasicDtoModel>> GetPageAsync(int page, int limit)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<PaginateResultModel<SRLSocialResponsabilityActionBasicDtoModel>>($"{USECASE_BASE_URI_SEGMENT}/page/{page}/limit/{limit}");
    }

    public Task<PaginateResultModel<SRLSocialResponsabilityActionBasicDtoModel>> FilterPageAsync(int page, int limit, string parameter)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<PaginateResultModel<SRLSocialResponsabilityActionBasicDtoModel>>($"{USECASE_BASE_URI_SEGMENT}/page/{page}/limit/{limit}/filter/{parameter}");
    }

    public Task<PaginateResultModel<SRLSocialResponsabilityActionBasicDtoModel>> FilterPageByOwnerAsync(Guid ownerId, int page, int limit)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<PaginateResultModel<SRLSocialResponsabilityActionBasicDtoModel>>($"{USECASE_BASE_URI_SEGMENT}/owner/{ownerId}/page/{page}/limit/{limit}");
    }
}
