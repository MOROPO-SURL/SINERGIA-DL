using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Entities;

public class ProgramAction : AbstractEntity<ProgramActionId, Guid>
{
    private ProgramAction() : base(new ProgramActionId(default)) { }

    public ProgramAction(ProgramActionId id, int index, string title, string? description = null) : base(id)
    {
        Index = index;
        Title = title;
        Description = description;
    }

    public StrategicAxesId StrategicAxesId { get; set; }

    public StrategicLineId StrategicLineId { get; set; }

    public StrategicProgramId StrategicProgramId { get; set; }

    public int Index { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public ProgramAction? Parent { get; set; }
    public ProgramActionId? ParentId { get; set; }

    public List<ProgramActionInterestAreaBridge> InterestAreaBridges { get; set; } = [];
}