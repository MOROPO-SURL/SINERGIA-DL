using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.SocialSupportDemand.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Models.Page.SocialSupportDemand;

public sealed class SocialSupportDemandsListPageModel : AbstractListEntityPageModel<SocialSupportDemandBasicDtoModel>
{
    protected override Task<PaginateResultModel<SocialSupportDemandBasicDtoModel>> FetchItemsAsync(int currentItemsPageNumber, int currentItemsPageLimit)
    {
        SocialSupportDemandQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        if (!string.IsNullOrEmpty(SearchParameter) && !string.IsNullOrWhiteSpace(SearchParameter))
        {
            return apiClient.FilterCurrentsPageAsync(currentItemsPageNumber, currentItemsPageLimit, SearchParameter);
        }

        return apiClient.GetCurrentsPageAsync(currentItemsPageNumber, currentItemsPageLimit);
    }
}
