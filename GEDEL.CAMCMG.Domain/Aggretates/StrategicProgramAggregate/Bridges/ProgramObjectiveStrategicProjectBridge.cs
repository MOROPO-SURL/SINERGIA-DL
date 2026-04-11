using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Bridges;

public class ProgramObjectiveStrategicProjectBridge
{
    private ProgramObjectiveStrategicProjectBridge() { }

    public ProgramObjectiveStrategicProjectBridge(ProgramObjectiveId programObjectiveId, StrategicProgramId strategicProgramId, StrategicProjectId linkedId, StrategicProject? linked = null)
    {
        ProgramObjectiveId = programObjectiveId;
        StrategicProgramId = strategicProgramId;
        LinkedId = linkedId;
        Linked = linked;
    }

    public ProgramObjectiveId ProgramObjectiveId { get; set; }

    public StrategicProgramId StrategicProgramId { get; set; }

    public StrategicProjectId LinkedId { get; set; }
    public StrategicProject? Linked { get; set; }
}
