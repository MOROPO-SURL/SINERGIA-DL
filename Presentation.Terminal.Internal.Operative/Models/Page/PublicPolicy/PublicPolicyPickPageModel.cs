using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.PublicPolicy.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.PublicPolicy;

public sealed class PublicPolicyPickPageModel : AbstractPickEntityPageModel<PublicPolicyBasicDtoModel>
{
    public PublicPolicyPickPageModel(Action<PublicPolicyBasicDtoModel> pickedCallbackAction) : base(pickedCallbackAction)
    {
    }

    protected override Task<PaginateResultModel<PublicPolicyBasicDtoModel>> FetchItemsAsync(int currentItemsPageNumber, int currentItemsPageLimit)
    {
        PublicPolicyQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        if (!string.IsNullOrEmpty(SearchParameter) && !string.IsNullOrWhiteSpace(SearchParameter))
        {
            return apiClient.FilterPageAsync(currentItemsPageNumber, currentItemsPageLimit, SearchParameter);
        }

        return apiClient.GetPageAsync(currentItemsPageNumber, currentItemsPageLimit);
    }
}
