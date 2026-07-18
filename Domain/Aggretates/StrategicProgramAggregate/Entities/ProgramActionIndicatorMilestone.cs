using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Entities;

public sealed class ProgramActionIndicatorMilestone : AbstractEntity<ProgramActionIndicatorMilestoneId, DateOnly>
{
    private ProgramActionIndicatorMilestone() : base(default) { }

    public ProgramActionIndicatorMilestone(ProgramActionIndicatorMilestoneId id, StrategicProgramId programId, ProgramActionId actionId, ProgramActionIndicatorId indicatorId, DateTime at, float amount, string? description = null) : base(id)
    {
        ProgramId = programId;
        ActionId = actionId;
        IndicatorId = indicatorId;
        Amount = amount;
        Description = description;
    }

    public StrategicProgramId ProgramId { get; set; }

    public ProgramActionId ActionId { get; set; }

    public ProgramActionIndicatorId IndicatorId { get; set; }

    public float Amount { get; set; }

    public string? Description { get; set; }
}
