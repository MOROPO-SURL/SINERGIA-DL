using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.PublicPolicyTrace.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.PublicPolicy.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using System.Windows.Input;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Helper;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.PublicPolicy;

public sealed class PublicPolicyDetailPageModel : AbstractDetailEntityPageModel<PublicPolicyDetailDtoModel>
{
    private PublicPolicyTraceDetailDtoModel[]? traces;

    public PublicPolicyDetailPageModel(PublicPolicyDetailDtoModel model, Action? changeCallbackAction = null) : base(model, changeCallbackAction)
    {
        FetchTraceCommand = new Command(() =>
        {
            IsBusy = true;

            PublicPolicyTraceQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

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

    public PublicPolicyTraceDetailDtoModel[]? Traces { get => traces; private set => SetProperty(ref traces, value); }

    public ICommand FetchTraceCommand { get; init; }

    protected override async Task PerformRemotionAsync(PublicPolicyDetailDtoModel model)
    {
        PublicPolicyCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        await apiClient.ArchiveAsync(model.Id);
    }
}
