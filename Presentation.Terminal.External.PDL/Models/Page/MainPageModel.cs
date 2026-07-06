using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Manager;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.Models.Page;

public sealed class MainPageModel : AbstractListEntityPageModel<OrganizationBasicDtoModel>
{
    protected override async Task<PaginateResultModel<OrganizationBasicDtoModel>> FetchItemsAsync(int currentItemsPageNumber, int currentItemsPageLimit)
    {
        ISessionManagerPort sessionManager = IPlatformApplication.Current!.Services.GetRequiredService<ISessionManagerPort>();

        OrganizationQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        Task<OrganizationBasicDtoModel[]> listLegalPDLTask = apiClient.GetByDevelopmentActorProfileKindAndUserAsync(GEDEL.CAMCMG.Interop.Contracts.Enumerations.DevelopmentActorProfileKind.LegalPDL, sessionManager.CurrentSession!.User.Id);
        Task<OrganizationBasicDtoModel[]> listNaturalPDLTask = apiClient.GetByDevelopmentActorProfileKindAndUserAsync(GEDEL.CAMCMG.Interop.Contracts.Enumerations.DevelopmentActorProfileKind.NaturalPDL, sessionManager.CurrentSession!.User.Id);

        await Task.WhenAll(listLegalPDLTask, listNaturalPDLTask);

        return new PaginateResultModel<OrganizationBasicDtoModel>
        {
            Page = 1,
            Limit = listLegalPDLTask.Result.Length + listNaturalPDLTask.Result.Length,
            HasNext = false,
            HasPrevious = false,
            MaxPageCount = 1,
            Items = [.. listLegalPDLTask.Result.Concat(listNaturalPDLTask.Result)]
        };
    }
}
