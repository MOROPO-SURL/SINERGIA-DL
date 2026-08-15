using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialResponsabilityAction.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.Models.Page.SocialResponsabilityAction;

public sealed class SocialResponsabilityActionsManagementPageModel : AbstractManagementEntityPageModel<PDLSocialResponsabilityActionBasicDtoModel>
{
    protected override Task<PaginateResultModel<PDLSocialResponsabilityActionBasicDtoModel>> FetchItemsAsync(int currentItemsPageNumber, int currentItemsPageLimit)
    {
        PDLSocialResponsabilityActionQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.FilterPageByOwnerAsync(((Application.Current!.MainPage as UI.Shells.AppShell)?.BindingContext as Common.Models.Page.AppShellPageModel)?.DevelopmentProfileId!.Value ?? default, currentItemsPageNumber, currentItemsPageLimit);
    }

    protected override void HandleException(Exception? exception)
    {
        if (exception is not null && exception.InnerException is NullReferenceException)
        {
            Application.Current!.MainPage!.DisplayAlert("Aviso", "No se ha definido el perfil de actor del desarrollo para esta entidad. Diríjase a la sección &#x0022;Perfil de actor del desarrollo&#x0022; para completar el proceso.", "Aceptar");
        }

        base.HandleException(exception);
    }
}