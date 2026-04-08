using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Bridges;

public class ProgramActionInterestAreaBridge : IBridge<ProgramAction, ProgramActionId, Guid, InterestArea, InterestAreaId, Guid>
{
    private ProgramActionInterestAreaBridge() { }

    public ProgramActionInterestAreaBridge(ProgramActionId mainId, InterestAreaId linkedId, ProgramAction? main = null, InterestArea? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Main = main;
        Linked = linked;
    }

    public ProgramActionId MainId { get; set; }
    public ProgramAction? Main { get; set; }

    public InterestAreaId LinkedId { get; set; }
    public InterestArea? Linked { get; set; }
}
