using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.TerritorialBarrier.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.TerritorialBarrierTrace.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Helper;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.TerritorialBarrier;

public sealed class TerritorialBarrierDetailPageModel : AbstractDetailEntityPageModel<TerritorialBarrierDetailDtoModel>
{
    private TerritorialBarrierTraceDetailDtoModel[]? traces;

    public TerritorialBarrierDetailPageModel(TerritorialBarrierDetailDtoModel model, Action? changeCallbackAction = null) : base(model, changeCallbackAction)
    {
        FetchTraceCommand = new Command(() =>
        {
            IsBusy = true;

            TerritorialBarrierTraceQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

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

    public TerritorialBarrierTraceDetailDtoModel[]? Traces { get => traces; private set => SetProperty(ref traces, value); }

    public ICommand FetchTraceCommand { get; init; }

    protected override async Task PerformRemotionAsync(TerritorialBarrierDetailDtoModel model)
    {
        TerritorialBarrierCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        await apiClient.ArchiveAsync(model.Id);
    }
}
