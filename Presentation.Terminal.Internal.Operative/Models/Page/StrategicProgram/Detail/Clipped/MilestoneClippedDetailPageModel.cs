using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Detail.Clipped;

public sealed class MilestoneClippedDetailPageModel : AbstractDetailEntityPageModel<ActionIndicatorMilestoneDetailDtoModel>
{
    public MilestoneClippedDetailPageModel(ActionIndicatorMilestoneDetailDtoModel model, Action? changeCallbackAction = null) : base(model, changeCallbackAction)
    {
    }

    protected override bool PresentChangeNotification => false;

    protected override Task PerformRemotionAsync(ActionIndicatorMilestoneDetailDtoModel model)
    {
        throw new NotImplementedException();
    }
}
