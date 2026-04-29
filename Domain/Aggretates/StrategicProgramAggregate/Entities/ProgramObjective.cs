using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Entities;

public class ProgramObjective : AbstractAuditableEntity<ProgramObjectiveId, int>, INamedEntity<ProgramObjectiveId, int>, IEnableableEntity<ProgramObjectiveId, int>
{
    private readonly List<ProgramObjectiveStrategicProjectBridge> strategicProjectBridges = [];

    private ProgramObjective() : base(new ProgramObjectiveId(default)) { }

    public ProgramObjective(ProgramObjectiveId id, StrategicProgramId strategicProgramId, bool isEnabled, string name, ProgramObjectiveStrategicProjectBridge[] strategicProjectBridges, string? description = null) : base(id)
    {
        StrategicProgramId = strategicProgramId;
        IsEnabled = isEnabled;
        Name = name;
        Description = description;

        this.strategicProjectBridges = [.. strategicProjectBridges];
    }

    public StrategicProgramId StrategicProgramId { get; set; }

    public bool IsEnabled { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public ProgramObjectiveStrategicProjectBridge[] StrategicProjectBridges => [.. strategicProjectBridges];
}
