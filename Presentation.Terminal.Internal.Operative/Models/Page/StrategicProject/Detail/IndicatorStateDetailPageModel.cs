using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.View;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProject.Detail;

public sealed class IndicatorStateDetailPageModel : AbstractDetailEntityPageModel<StrategicProjectIndicatorStateViewModel>
{
    public IndicatorStateDetailPageModel(StrategicProjectIndicatorStateViewModel model) : base(model, null)
    {
    }

    protected override Task PerformRemotionAsync(StrategicProjectIndicatorStateViewModel model)
    {
        throw new InvalidOperationException();
    }
}