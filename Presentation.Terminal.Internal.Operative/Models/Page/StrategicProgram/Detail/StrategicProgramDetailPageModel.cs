using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgramTrace.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Helper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProgram.Detail.Clipped;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Detail;

public sealed class StrategicProgramDetailPageModel : AbstractDetailEntityPageModel<StrategicProgramDetailDtoModel>
{
    private StrategicProgramTraceDetailDtoModel[]? traces;

    public StrategicProgramDetailPageModel(StrategicProgramDetailDtoModel model, Action? changeCallbackAction = null) : base(model, changeCallbackAction)
    {
        DetailSpecificObjectiveCommand = new Command<SpecificObjectiveDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new SpecificObjectiveClippedDetailPage(model));
        });

        DetailImpactCommand = new Command<ImpactDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new ImpactClippedDetailPage(model));
        });

        DetailActionCommand = new Command<ActionDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new ActionClippedDetailPage(model));
        });

        FetchTraceCommand = new Command(() =>
        {
            IsBusy = true;

            StrategicProgramTraceQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

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

    public StrategicProgramTraceDetailDtoModel[]? Traces { get => traces; private set => SetProperty(ref traces, value); }

    public ICommand FetchTraceCommand { get; init; }

    public ICommand DetailSpecificObjectiveCommand { get; init; }

    public ICommand DetailImpactCommand { get; init; }

    public ICommand DetailActionCommand { get; init; }

    protected override async Task PerformRemotionAsync(StrategicProgramDetailDtoModel model)
    {
        StrategicProgramCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        await apiClient.ArchiveAsync(model.Id);
    }
}