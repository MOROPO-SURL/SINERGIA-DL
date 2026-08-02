using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.OperationReport.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Models.Page.OperationReport;

public sealed class OperationReportsManagementPageModel : AbstractManagementEntityPageModel<SRLOperationReportBasicDtoModel>
{
    protected override Task<PaginateResultModel<SRLOperationReportBasicDtoModel>> FetchItemsAsync(int currentItemsPageNumber, int currentItemsPageLimit)
    {
        SRLOperationReportQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.FilterPageByOwnerAsync(((Common.Models.Page.AppShellPageModel)((UI.Shells.AppShell)Application.Current!.MainPage!).BindingContext).DevelopmentProfileId!.Value, currentItemsPageNumber, currentItemsPageLimit);
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
