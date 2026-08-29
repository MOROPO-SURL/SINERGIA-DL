using CommunityToolkit.Maui.Storage;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Document.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.OperationReport.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Helper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Models.Page;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Models.Page.OperationReport;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.UI.Pages.OperationReport;

public partial class OperationReportDetailPage : BaseDetailEntityPage<SRLOperationReportDetailDtoModel, OperationReportDetailPageModel>, IDetailItemPageModelPresenter<SRLOperationReportDetailDtoModel>
{
    public OperationReportDetailPage(SRLOperationReportDetailDtoModel model) : base(new OperationReportDetailPageModel(model))
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
    }

    public Task PresentItemModifyUserInterfaceAsync(SRLOperationReportDetailDtoModel model, Action<SRLOperationReportDetailDtoModel> configurationSuccessCallbackAction)
    {
        return this.NavigationPushPageAsync(new OperationReportConfigurationPage(new OperationReportConfigurationPageModel(((AppShellPageModel)((Shells.AppShell)Application.Current!.MainPage!).BindingContext).DevelopmentProfileId!.Value, model, configurationSuccessCallbackAction, new Validators.OperationReportConfigurationValidator())));
    }

    private void DocumentDownloadButton_Clicked(object sender, EventArgs e)
    {
        DocumentBasicDtoModel model = (DocumentBasicDtoModel)((BindableObject)sender).BindingContext;

        ConcreteBindingContext.IsBusy = true;

        HttpClient httpClient = new()
        {
            Timeout = TimeSpan.FromSeconds(30.0)
        };

        httpClient.GetByteArrayAsync($"{Terminal.Common.Constants.InteropConstants.API_BASE_URL}/media/documents/{model.Id}{model.Extension}").ContinueWith(task =>
        {
            Dispatcher.Dispatch(async () =>
            {
                if (!task.IsCompletedSuccessfully)
                {
                    IPlatformApplication.Current!.Services.GetRequiredService<IExceptionHandlingHelperPort>().HandleException(task.Exception);
                }
                else
                {
                    FileSaverResult fileSaverResult = await FileSaver.Default.SaveAsync($"{model.Name}{model.Extension}", new MemoryStream(task.Result));

                    if (fileSaverResult.IsSuccessful)
                    {
                        Application.Current!.PresentToastNotification(Terminal.Common.Enumerations.NotificationKind.Success, "Archivo descargado con éxito.");
                    }
                    else if (fileSaverResult.FilePath != null)
                    {
                        Application.Current!.PresentToastNotification(Terminal.Common.Enumerations.NotificationKind.Error, "No fue posible salvar el archivo.");
                    }
                }

                ConcreteBindingContext.IsBusy = false;
            });
        });
    }
}