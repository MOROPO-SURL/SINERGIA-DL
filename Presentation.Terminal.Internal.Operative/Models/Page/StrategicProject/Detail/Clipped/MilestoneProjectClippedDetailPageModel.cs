using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProject.Detail.Clipped;

public sealed class MilestoneProjectClippedDetailPageModel : AbstractDetailEntityPageModel<IndicatorMilestoneDetailDtoModel>
{
    public MilestoneProjectClippedDetailPageModel(IndicatorMilestoneDetailDtoModel model, Action? changeCallbackAction = null) : base(model, changeCallbackAction)
    {
    }

    protected override bool PresentChangeNotification => false;

    protected override Task PerformRemotionAsync(IndicatorMilestoneDetailDtoModel model)
    {
        throw new NotImplementedException();
    }
}
