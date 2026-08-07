using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Objective.Detail;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Objective.Detail;

public sealed class ObjectiveIndicatorDetailPageModel : AbstractDetailEntityPageModel<ObjectiveActionIndicatorDetailDtoModel>
{
    public ObjectiveIndicatorDetailPageModel(ObjectiveActionIndicatorDetailDtoModel model, Action? changeCallbackAction = null) : base(model, changeCallbackAction)
    {
        DetailMilestoneCommand = new Command<ObjectiveActionIndicatorMilestoneDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new ObjectiveMilestoneDetailPage(model));
        });
    }

    protected override bool PresentChangeNotification => false;

    protected override Task PerformRemotionAsync(ObjectiveActionIndicatorDetailDtoModel model)
    {
        throw new NotImplementedException();
    }

    public ICommand DetailMilestoneCommand { get; init; }
}
