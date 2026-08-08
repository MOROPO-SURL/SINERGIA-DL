using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Objective.Detail;

public sealed class ObjectiveMilestoneDetailPageModel : AbstractDetailEntityPageModel<ObjectiveActionIndicatorMilestoneDetailDtoModel>
{
    public ObjectiveMilestoneDetailPageModel(ObjectiveActionIndicatorMilestoneDetailDtoModel model, Action? changeCallbackAction = null) : base(model, changeCallbackAction)
    {
    }

    protected override bool PresentChangeNotification => false;

    protected override Task PerformRemotionAsync(ObjectiveActionIndicatorMilestoneDetailDtoModel model)
    {
        throw new NotImplementedException();
    }
}
