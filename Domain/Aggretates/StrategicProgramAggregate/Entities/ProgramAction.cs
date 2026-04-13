using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Entities;

public class ProgramAction : AbstractEntity<ProgramActionId, Guid>, IPriorizableEntity<ProgramActionId, Guid>
{
    private readonly List<ProgramActionInterestAreaBridge> interestAreaBridges = [];

    private ProgramAction() : base(new ProgramActionId(default)) { }

    public ProgramAction(ProgramActionId id, string title, int priority, ProgramActionInterestAreaBridge[] interestAreaBridges, string? description = null) : base(id)
    {
        Priority = priority;
        Title = title;
        Description = description;

        this.interestAreaBridges = [.. interestAreaBridges];
    }

    public StrategicProgramId StrategicProgramId { get; set; }

    public string Title { get; set; } = null!;

    public int Priority { get; set; }

    public string? Description { get; set; }

    //public ProgramAction? Parent { get; set; }
    //public ProgramActionId? ParentId { get; set; }

    public ProgramActionInterestAreaBridge[] InterestAreaBridges => [.. interestAreaBridges];
}