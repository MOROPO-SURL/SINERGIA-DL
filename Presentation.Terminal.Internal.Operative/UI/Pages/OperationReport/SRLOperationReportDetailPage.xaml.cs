using CommunityToolkit.Maui.Storage;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Document.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.OperationReport.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Helper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.OperationReport;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.OperationReport;

public partial class SRLOperationReportDetailPage : BaseDetailEntityPage<SRLOperationReportDetailDtoModel, SRLOperationReportDetailPageModel>
{
    public SRLOperationReportDetailPage(SRLOperationReportDetailDtoModel model) : base(new SRLOperationReportDetailPageModel(model))
    {
        InitializeComponent();
    }

    private void DocumentDownloadButton_Clicked(object sender, EventArgs e)
    {
        DocumentBasicDtoModel model = (DocumentBasicDtoModel)((BindableObject)sender).BindingContext;

        ConcreteBindingContext.IsBusy = true;

        HttpClient httpClient = new()
        {
            Timeout = TimeSpan.FromSeconds(30.0)
        };

        httpClient.GetByteArrayAsync($"{Common.Constants.InteropConstants.API_BASE_URL}/media/documents/{model.Id}{model.Extension}").ContinueWith(task =>
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
                        Application.Current!.PresentToastNotification(Common.Enumerations.NotificationKind.Success, "Archivo descargado con éxito.");
                    }
                    else if (fileSaverResult.FilePath != null)
                    {
                        Application.Current!.PresentToastNotification(Common.Enumerations.NotificationKind.Error, "No fue posible salvar el archivo.");
                    }
                }

                ConcreteBindingContext.IsBusy = false;
            });
        });
    }
}