using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.View;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Detail;

public sealed class IndicatorStateDetailPageModel : AbstractDetailEntityPageModel<View.IndicatorStateViewModel>
{
    public IndicatorStateDetailPageModel(IndicatorStateViewModel model) : base(model, null)
    {
    }

    protected override Task PerformRemotionAsync(IndicatorStateViewModel model)
    {
        throw new InvalidOperationException();
    }
}