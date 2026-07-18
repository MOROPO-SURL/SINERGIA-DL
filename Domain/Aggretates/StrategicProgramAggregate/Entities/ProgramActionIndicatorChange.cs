using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Entities;

public sealed class ProgramActionIndicatorChange : AbstractEntity<ProgramActionIndicatorChangeId, DateTime>
{
    private ProgramActionIndicatorChange() : base(default) { }

    public ProgramActionIndicatorChange(ProgramActionIndicatorChangeId id, StrategicProgramId programId, ProgramActionId actionId, ProgramActionIndicatorId indicatorId, float amount, string? context = null) : base(id)
    {
        ProgramId = programId;
        ActionId = actionId;
        IndicatorId = indicatorId;
        Amount = amount;
        Context = context;
    }

    public StrategicProgramId ProgramId { get; set; }

    public ProgramActionId ActionId { get; set; }

    public ProgramActionIndicatorId IndicatorId { get; set; }

    public float Amount { get; set; }

    public string? Context { get; set; }
}
