using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialResponsabilityAction.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;

public sealed class PDLSocialResponsabilityActionQueryApiClient
{
    private const string USECASE_BASE_URI_SEGMENT = "api/pdlsocialresponsabilityactions";

    private readonly IHttpClientProviderPort httpClientProvider;

    public PDLSocialResponsabilityActionQueryApiClient(IHttpClientProviderPort httpClientProvider)
    {
        this.httpClientProvider = httpClientProvider;
    }

    public Task<PDLSocialResponsabilityActionDetailDtoModel> GetAsync(Guid id)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<PDLSocialResponsabilityActionDetailDtoModel>($"{USECASE_BASE_URI_SEGMENT}/{id}");
    }

    public Task<PaginateResultModel<PDLSocialResponsabilityActionBasicDtoModel>> GetPageAsync(int page, int limit)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<PaginateResultModel<PDLSocialResponsabilityActionBasicDtoModel>>($"{USECASE_BASE_URI_SEGMENT}/page/{page}/limit/{limit}");
    }

    public Task<PaginateResultModel<PDLSocialResponsabilityActionBasicDtoModel>> FilterPageByOwnerAsync(Guid ownerId, int page, int limit)
    {
        return httpClientProvider.GetHttpClient().SendGetAsync<PaginateResultModel<PDLSocialResponsabilityActionBasicDtoModel>>($"{USECASE_BASE_URI_SEGMENT}/owner/{ownerId}/page/{page}/limit/{limit}");
    }
}