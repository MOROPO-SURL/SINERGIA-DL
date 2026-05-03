using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicAxe;

public sealed class StrategicAxesManagementPageModel : AbstractManagementEntityPageModel<StrategicAxeBasicDtoModel>
{
    // TODO Set permissions !!!

    //protected override string? ViewerPermissionCode => ;

    //protected override string? DetailPermissionCode => ;

    protected override Task<PaginateResultModel<StrategicAxeBasicDtoModel>> FetchItemsAsync(int currentItemsPageNumber, int currentItemsPageLimit)
    {
        StrategicAxeQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        if (!string.IsNullOrEmpty(SearchParameter) && !string.IsNullOrWhiteSpace(SearchParameter))
        {
            return apiClient.FilterPageAsync(currentItemsPageNumber, currentItemsPageLimit, SearchParameter);
        }

        return apiClient.GetPageAsync(currentItemsPageNumber, currentItemsPageLimit);
    }
}