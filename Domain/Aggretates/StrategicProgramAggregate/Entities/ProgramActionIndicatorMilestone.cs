using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Entities;

public sealed class ProgramActionIndicatorMilestone : AbstractEntity<ProgramActionIndicatorMilestoneId, Guid>
{
    private ProgramActionIndicatorMilestone() : base(default) { }

    public ProgramActionIndicatorMilestone(ProgramActionIndicatorMilestoneId id, ProgramActionIndicatorId indicatorId, ProgramActionId actionId, StrategicProgramId programId, DateOnly at, float amount, string? description = null) : base(id)
    {
        ProgramId = programId;
        ActionId = actionId;
        IndicatorId = indicatorId;
        At = at;
        Amount = amount;
        Description = description;
    }

    public StrategicProgramId ProgramId { get; set; }

    public ProgramActionId ActionId { get; set; }

    public ProgramActionIndicatorId IndicatorId { get; set; }

    public DateOnly At { get; set; }

    public float Amount { get; set; }

    public string? Description { get; set; }
}
