using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.View;

public sealed class StrategicProjectIndicatorStateViewModel : BaseBindableModel
{
    private IndicatorChangeProjectDetailDtoModel? lastChange;

    public StrategicProjectIndicatorStateViewModel(Guid actionId, IndicatorDetailDtoModel indicator, IndicatorMilestoneDetailDtoModel targetMilestone, IndicatorChangeProjectDetailDtoModel? lastChange = null)
    {
        Indicator = indicator;
        TargetMilestone = targetMilestone;

        this.lastChange = lastChange;
    }

    public IndicatorDetailDtoModel Indicator { get; init; }

    public IndicatorMilestoneDetailDtoModel TargetMilestone { get; init; }

    public IndicatorChangeProjectDetailDtoModel? LastChange { get => lastChange; set => SetProperty(ref lastChange, value); }
}
