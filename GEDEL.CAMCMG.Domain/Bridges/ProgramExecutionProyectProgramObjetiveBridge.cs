using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Bridges;

public class ProgramExecutionProyectProgramObjetiveBridge : IBridge<ProgramExecutionProject, ProgramExecutionProjectId, Guid, ProgramObjetive, ProgramObjetiveId, Guid>
{
    private ProgramExecutionProyectProgramObjetiveBridge() { }

    public ProgramExecutionProyectProgramObjetiveBridge(ProgramExecutionProjectId mainId, ProgramObjetiveId linkedId, ProgramExecutionProject? main = null, ProgramObjetive? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Main = main;
        Linked = linked;
    }

    public ProgramExecutionProjectId MainId { get; set; }
    public ProgramExecutionProject? Main { get; set; }

    public ProgramObjetiveId LinkedId { get; set; }
    public ProgramObjetive? Linked { get; set; }
}
