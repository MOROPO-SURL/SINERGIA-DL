using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Bridges;

public class ProgramActionInterestAreaBridge
{
    private ProgramActionInterestAreaBridge() { }

    public ProgramActionInterestAreaBridge(ProgramActionId programActionId, StrategicAxesId strategicAxesId, StrategicLineId strategicLineId, StrategicProgramId strategicProgramId, InterestAreaId linkedId, InterestArea? linked = null)
    {
        ProgramActionId = programActionId;
        StrategicAxesId = strategicAxesId;
        StrategicLineId = strategicLineId;
        StrategicProgramId = strategicProgramId;
        LinkedId = linkedId;
        Linked = linked;
    }

    public ProgramActionId ProgramActionId { get; set; }

    public StrategicAxesId StrategicAxesId { get; set; }

    public StrategicLineId StrategicLineId { get; set; }

    public StrategicProgramId StrategicProgramId { get; set; }

    public InterestAreaId LinkedId { get; set; }
    public InterestArea? Linked { get; set; }
}
