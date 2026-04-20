using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.KeyVariableAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.KeyVariableAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Bridges;

public class ObjectiveKeyVariableBridge : IBridge<Objective, ObjectiveId, Guid, KeyVariable, KeyVariableId, Guid>
{
    private ObjectiveKeyVariableBridge() { }

    public ObjectiveKeyVariableBridge(ObjectiveId mainId, KeyVariableId linkedId, Objective? main = null, KeyVariable? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Main = main;
        Linked = linked;
    }

    public ObjectiveId MainId { get; set; }
    public Objective? Main { get; set; }

    public KeyVariableId LinkedId { get; set; }
    public KeyVariable? Linked { get; set; }
}