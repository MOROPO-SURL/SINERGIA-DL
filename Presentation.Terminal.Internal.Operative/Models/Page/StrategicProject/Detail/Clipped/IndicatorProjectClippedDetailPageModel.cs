using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProject.Detail.Clipped;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProject.Detail.Clipped;

public sealed class IndicatorProjectClippedDetailPageModel : AbstractDetailEntityPageModel<IndicatorDetailDtoModel>
{
    public IndicatorProjectClippedDetailPageModel(IndicatorDetailDtoModel model, Action? changeCallbackAction = null) : base(model, changeCallbackAction)
    {
        DetailMilestoneCommand = new Command<IndicatorMilestoneDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new MilestoneProjectClippedDetailPage(model));
        });
    }

    protected override bool PresentChangeNotification => false;

    protected override Task PerformRemotionAsync(IndicatorDetailDtoModel model)
    {
        throw new NotImplementedException();
    }

    public ICommand DetailMilestoneCommand { get; init; }
}
