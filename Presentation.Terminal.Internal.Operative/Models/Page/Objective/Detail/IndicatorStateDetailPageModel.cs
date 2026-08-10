using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.View;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Objective.Detail;

public sealed class IndicatorStateDetailPageModel : AbstractDetailEntityPageModel<ObjectiveIndicatorStateViewModel>
{
    public IndicatorStateDetailPageModel(ObjectiveIndicatorStateViewModel model) : base(model, null)
    {
    }

    protected override Task PerformRemotionAsync(ObjectiveIndicatorStateViewModel model)
    {
        throw new InvalidOperationException();
    }
}