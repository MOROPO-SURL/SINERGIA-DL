using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Factories;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Enumerations;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Helper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages;

public partial class DiagnosticSummaryPage : BaseBindingContextedContentPage<DiagnosticSummaryPageModel>
{
	public DiagnosticSummaryPage() : base(new DiagnosticSummaryPageModel())
	{
		InitializeComponent();

        IsEnabled = false;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (IsEnabled) return;

        IsEnabled = true;

        ReloadToolbarItem_Clicked(this, EventArgs.Empty);
    }

    private void ReloadToolbarItem_Clicked(object sender, EventArgs eventArgs)
    {
        ConcreteBindingContext.LoadSummary();
    }

    private void DownloadToolbarItems_Clicked(object sender, EventArgs eventArgs)
    {
        if (ConcreteBindingContext.IsBusy) return;

        var httpClientHelperProvider = IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>();

        ConcreteBindingContext.IsBusy = true;

        var httpClient = new HttpClient(HttpClientHandlerFactory.Build())
        {
            Timeout = TimeSpan.FromSeconds(30.0)
        };

        httpClient.GetByteArrayAsync(Constants.InteropConstants.REPORT_DIAGNOSTIC_URL).ContinueWith(task =>
        {
            Dispatcher.Dispatch(async () =>
            {
                if (task.IsCanceled || task.Exception != null)
                {
                    IPlatformApplication.Current!.Services.GetRequiredService<IExceptionHandlingHelperPort>().HandleException(task.Exception);
                }
                else
                {
                    var fileSaverResult = await CommunityToolkit.Maui.Storage.FileSaver.Default.SaveAsync($"Resumen de Diagnóstico {DateTime.Now:dd-MM-yyyy}.pdf", new System.IO.MemoryStream(task.Result));

                    if (fileSaverResult.IsSuccessful)
                    {
                        Application.Current!.PresentToastNotification(NotificationKind.Success, "Archivo descargado con éxito.");
                    }
                    else if (fileSaverResult.FilePath != null)
                    {
                        Application.Current!.PresentToastNotification(NotificationKind.Error, "No fue posible salvar el archivo.");
                    }
                }

                ConcreteBindingContext.IsBusy = false;
            });
        });
    }
}