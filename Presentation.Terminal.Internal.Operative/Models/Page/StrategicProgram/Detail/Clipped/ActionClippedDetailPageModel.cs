using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProgram.Detail.Clipped;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Detail.Clipped;

public sealed class ActionClippedDetailPageModel : AbstractDetailEntityPageModel<ActionDetailDtoModel>
{
    public ActionClippedDetailPageModel(ActionDetailDtoModel model) : base(model, null)
    {
        DetailIndicatorCommand = new Command<ActionIndicatorDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new IndicatorClippedDetailPage(model));
        });
    }

    protected override bool PresentChangeNotification => false;

    protected override Task PerformRemotionAsync(ActionDetailDtoModel model)
    {
        throw new NotImplementedException();
    }

    public ICommand DetailIndicatorCommand { get; init; }
}