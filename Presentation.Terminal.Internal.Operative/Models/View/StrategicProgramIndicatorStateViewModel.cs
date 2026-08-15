using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.View;

public sealed class StrategicProgramIndicatorStateViewModel : BaseBindableModel
{
    private IndicatorChangeDetailDtoModel? lastChange;

    public StrategicProgramIndicatorStateViewModel(Guid actionId, ActionIndicatorDetailDtoModel indicator, ActionIndicatorMilestoneDetailDtoModel targetMilestone, IndicatorChangeDetailDtoModel? lastChange = null)
    {
        ActionId = actionId;
        Indicator = indicator;
        TargetMilestone = targetMilestone;

        this.lastChange = lastChange;
    }

    public Guid ActionId { get; init; }

    public ActionIndicatorDetailDtoModel Indicator { get; init; }
    
    public ActionIndicatorMilestoneDetailDtoModel TargetMilestone { get; init; }
    
    public IndicatorChangeDetailDtoModel? LastChange { get => lastChange; set => SetProperty(ref lastChange, value); }
}