using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProjectTrace.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Helper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProject.Detail.Clipped;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProject.Detail;

public sealed class StrategicProjectDetailPageModel : AbstractDetailEntityPageModel<StrategicProjectDetailDtoModel>
{
    private StrategicProjectTraceDetailDtoModel[]? traces;

    public StrategicProjectDetailPageModel(StrategicProjectDetailDtoModel model, Action? changeCallbackAction = null) : base(model, changeCallbackAction)
    {
        DetailSpecificObjectiveCommand = new Command<SpecificObjectiveProjectDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new SpecificObjectiveProjectClippedDetailPage(model));
        });

        DetailIndicatorCommand = new Command<IndicatorDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new IndicatorProjectClippedDetailPage(model));
        });

        FetchTraceCommand = new Command(() =>
        {
            IsBusy = true;

            StrategicProjectTraceQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

            apiClient.GetForTargetAsync(Model.Id).ContinueWith(task =>
            {
                Dispatcher.Dispatch(() =>
                {
                    if (!task.IsCompletedSuccessfully)
                    {
                        IPlatformApplication.Current!.Services.GetRequiredService<IExceptionHandlingHelperPort>().HandleException(task.Exception);
                    }
                    else
                    {
                        Traces = task.Result;
                    }

                    IsBusy = false;
                });
            });
        });
    }

    public StrategicProjectTraceDetailDtoModel[]? Traces { get => traces; private set => SetProperty(ref traces, value); }

    public ICommand FetchTraceCommand { get; init; }

    public ICommand DetailSpecificObjectiveCommand { get; init; }

    public ICommand DetailIndicatorCommand { get; init; }

    protected override async Task PerformRemotionAsync(StrategicProjectDetailDtoModel model)
    {
        StrategicProjectCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        await apiClient.ArchiveAsync(model.Id);
    }
}