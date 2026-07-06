using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Manager;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Models.Page;

public sealed class MainPageModel : AbstractListEntityPageModel<OrganizationBasicDtoModel>
{
    protected override async Task<PaginateResultModel<OrganizationBasicDtoModel>> FetchItemsAsync(int currentItemsPageNumber, int currentItemsPageLimit)
    {
        ISessionManagerPort sessionManager = IPlatformApplication.Current!.Services.GetRequiredService<ISessionManagerPort>();

        OrganizationQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        Task<OrganizationBasicDtoModel[]> listTask = apiClient.GetByDevelopmentActorProfileKindAndUserAsync(GEDEL.CAMCMG.Interop.Contracts.Enumerations.DevelopmentActorProfileKind.SRL, sessionManager.CurrentSession!.User.Id);

        await listTask;

        return new PaginateResultModel<OrganizationBasicDtoModel>
        {
            Page = 1,
            Limit = listTask.Result.Length,
            HasNext = false,
            HasPrevious = false,
            MaxPageCount = 1,
            Items = [.. listTask.Result]
        };
    }
}
