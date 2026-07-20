using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProgram.Detail.Clipped;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Detail.Clipped;

public sealed class IndicatorClippedDetailPageModel : AbstractDetailEntityPageModel<ActionIndicatorDetailDtoModel>
{
    public IndicatorClippedDetailPageModel(ActionIndicatorDetailDtoModel model, Action? changeCallbackAction = null) : base(model, changeCallbackAction)
    {
        DetailMilestoneCommand = new Command<ActionIndicatorMilestoneDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new MilestoneClippedDetailPage(model));
        });
    }

    protected override bool PresentChangeNotification => false;

    protected override Task PerformRemotionAsync(ActionIndicatorDetailDtoModel model)
    {
        throw new NotImplementedException();
    }

    public ICommand DetailMilestoneCommand { get; init; }
}
