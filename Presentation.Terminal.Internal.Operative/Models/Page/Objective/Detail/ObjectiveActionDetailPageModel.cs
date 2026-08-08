using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Objective.Detail;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Objective.Detail;

public sealed class ObjectiveActionDetailPageModel : AbstractDetailEntityPageModel<ObjectiveActionDetailDtoModel>
{
    public ObjectiveActionDetailPageModel(ObjectiveActionDetailDtoModel model) : base(model, null)
    {
        DetailIndicatorCommand = new Command<ObjectiveActionIndicatorDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new ObjectiveIndicatorDetailPage(model));
        });
    }

    protected override bool PresentChangeNotification => false;

    protected override Task PerformRemotionAsync(ObjectiveActionDetailDtoModel model)
    {
        throw new NotImplementedException();
    }

    public ICommand DetailIndicatorCommand { get; init; }
}