using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.View;

public sealed class StrategicProjectIndicatorStateViewModel : BaseBindableModel
{
    private IndicatorChangeDetailDtoModel? lastChange;

    public StrategicProjectIndicatorStateViewModel(IndicatorDetailDtoModel indicator, IndicatorMilestoneDetailDtoModel targetMilestone, IndicatorChangeDetailDtoModel? lastChange = null)
    {
        Indicator = indicator;
        TargetMilestone = targetMilestone;

        this.lastChange = lastChange;
    }

    public IndicatorDetailDtoModel Indicator { get; init; }
    
    public IndicatorMilestoneDetailDtoModel TargetMilestone { get; init; }
    
    public IndicatorChangeDetailDtoModel? LastChange { get => lastChange; set => SetProperty(ref lastChange, value); }
}