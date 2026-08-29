using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Bridges;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Entities;

public class ProgramSpecificObjective : AbstractAuditableEntity<ProgramSpecificObjectiveId, Guid>
{
    private readonly List<ProgramSpecificObjectiveStrategicProjectBridge> projectBridges = [];

    private ProgramSpecificObjective() : base(default) { }

    public ProgramSpecificObjective(ProgramSpecificObjectiveId id, StrategicProgramId programId, int index, string content, IEnumerable<ProgramSpecificObjectiveStrategicProjectBridge> projectBridges) : base(id)
    {
        ProgramId = programId;
        Index = index;
        Content = content;

        this.projectBridges = [.. projectBridges];
    }

    public StrategicProgramId ProgramId { get; set; }

    public int Index { get; set; }

    public string Content { get; set; } = null!;

    public IReadOnlyList<ProgramSpecificObjectiveStrategicProjectBridge> ProjectBridges => [.. projectBridges];
}
