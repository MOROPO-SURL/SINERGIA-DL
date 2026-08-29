using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicLine.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicLineTrace.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Helper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicLine.Detail;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicLine.Detail;

public sealed class StrategicLineDetailPageModel : AbstractDetailEntityPageModel<StrategicLineDetailDtoModel>
{
    private StrategicLineTraceDetailDtoModel[]? traces;

    public StrategicLineDetailPageModel(StrategicLineDetailDtoModel model, Action? changeCallbackAction = null) : base(model, changeCallbackAction)
    {
        DetailSpecificObjectiveCommand = new Command<SpecificObjectiveDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new StrategicLineSpecificObjectiveDetailPage(model));
        });

        FetchTraceCommand = new Command(() =>
        {
            IsBusy = true;

            StrategicLineTraceQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

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

    public StrategicLineTraceDetailDtoModel[]? Traces { get => traces; private set => SetProperty(ref traces, value); }

    public ICommand FetchTraceCommand { get; init; }

    public ICommand DetailSpecificObjectiveCommand { get; init; }

    protected override async Task PerformRemotionAsync(StrategicLineDetailDtoModel model)
    {
        StrategicLineCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        await apiClient.ArchiveAsync(model.Id);
    }
}