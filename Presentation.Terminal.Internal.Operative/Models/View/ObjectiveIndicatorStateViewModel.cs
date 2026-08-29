using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.View;

public sealed class ObjectiveIndicatorStateViewModel : BaseBindableModel
{
    private IndicatorChangeDetailDtoModel? lastChange;

    public ObjectiveIndicatorStateViewModel(Guid actionId, ObjectiveActionIndicatorDetailDtoModel indicator, ObjectiveActionIndicatorMilestoneDetailDtoModel targetMilestone, IndicatorChangeDetailDtoModel? lastChange = null)
    {
        ActionId = actionId;
        Indicator = indicator;
        TargetMilestone = targetMilestone;

        this.lastChange = lastChange;
    }

    public Guid ActionId { get; init; }

    public ObjectiveActionIndicatorDetailDtoModel Indicator { get; init; }
    
    public ObjectiveActionIndicatorMilestoneDetailDtoModel TargetMilestone { get; init; }
    
    public IndicatorChangeDetailDtoModel? LastChange { get => lastChange; set => SetProperty(ref lastChange, value); }
}