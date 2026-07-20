using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Bridges;

public class ProgramSpecificObjectiveStrategicProjectBridge
{
    private ProgramSpecificObjectiveStrategicProjectBridge() { }

    public ProgramSpecificObjectiveStrategicProjectBridge(ProgramSpecificObjectiveId programObjectiveId, StrategicProgramId strategicProgramId, StrategicProjectId linkedId, StrategicProject? linked = null)
    {
        ProgramObjectiveId = programObjectiveId;
        StrategicProgramId = strategicProgramId;
        LinkedId = linkedId;
        Linked = linked;
    }

    public ProgramSpecificObjectiveId ProgramObjectiveId { get; set; }

    public StrategicProgramId StrategicProgramId { get; set; }

    public StrategicProjectId LinkedId { get; set; }
    public StrategicProject? Linked { get; set; }
}
