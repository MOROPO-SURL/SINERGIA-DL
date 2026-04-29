using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Bridges;

public class ProgramActionInterestAreaBridge
{
    private ProgramActionInterestAreaBridge() { }

    public ProgramActionInterestAreaBridge(ProgramActionId programActionId, StrategicProgramId strategicProgramId, InterestAreaId linkedId, InterestArea? linked = null)
    {
        ProgramActionId = programActionId;
        StrategicProgramId = strategicProgramId;
        LinkedId = linkedId;
        Linked = linked;
    }

    public ProgramActionId ProgramActionId { get; set; }

    public StrategicProgramId StrategicProgramId { get; set; }

    public InterestAreaId LinkedId { get; set; }
    public InterestArea? Linked { get; set; }
}
