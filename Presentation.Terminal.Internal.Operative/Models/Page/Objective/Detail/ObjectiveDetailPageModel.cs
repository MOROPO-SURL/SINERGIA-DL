using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages.Objective.Detail;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Objective.Detail;

public sealed class ObjectiveDetailPageModel : AbstractDetailEntityPageModel<ObjectiveDetailDtoModel>
{
    public ObjectiveDetailPageModel(ObjectiveDetailDtoModel model, Action? changeCallbackAction = null) : base(model, changeCallbackAction)
    {
        DetailChallangeCommand = new Command<ObjectiveChallengeDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new ObjectiveChallengeDetailPage(model));
        });

        DetailProjectionCommand = new Command<ObjectiveProjectionDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new ObjectiveProjectionDetailPage(model));
        });

        DetailActionCommand = new Command<ObjectiveActionDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new ObjectiveActionDetailPage(model));
        });
    }

    public ICommand DetailChallangeCommand { get; private set; }

    public ICommand DetailProjectionCommand { get; private set; }

    public ICommand DetailActionCommand { get; private set; }

    protected override async Task PerformRemotionAsync(ObjectiveDetailDtoModel model)
    {
        ObjectiveCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        await apiClient.ArchiveAsync(model.Id);
    }
}
