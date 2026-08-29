using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProjectIdea.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProjectIdea;

public sealed class StrategicProjectIdeasManagementPageModel : AbstractManagementEntityPageModel<StrategicProjectIdeaBasicDtoModel>
{
    // TODO Set permissions !!!

    //protected override string? ViewerPermissionCode => ;

    //protected override string? DetailPermissionCode => ;

    protected override Task<PaginateResultModel<StrategicProjectIdeaBasicDtoModel>> FetchItemsAsync(int currentItemsPageNumber, int currentItemsPageLimit)
    {
        StrategicProjectIdeaQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        if (!string.IsNullOrEmpty(SearchParameter) && !string.IsNullOrWhiteSpace(SearchParameter))
        {
            return apiClient.FilterPageAsync(currentItemsPageNumber, currentItemsPageLimit, SearchParameter);
        }

        return apiClient.GetPageAsync(currentItemsPageNumber, currentItemsPageLimit);
    }
}