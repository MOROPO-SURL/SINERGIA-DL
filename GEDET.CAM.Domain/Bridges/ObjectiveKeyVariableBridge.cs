using MOROPO.GEDET.CAM.Domain.Aggretates.KeyVariableAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.KeyVariableAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.ObjectiveAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.ObjectiveAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Bridges;

public class ObjectiveKeyVariableBridge : IBridge<Objective, ObjectiveId, KeyVariable, KeyVariableId>
{
    private ObjectiveKeyVariableBridge() { }

    public ObjectiveKeyVariableBridge(ObjectiveId mainId, Objective main, KeyVariableId linkedId, KeyVariable linked)
    {
        MainId = mainId;
        Main = main;
        LinkedId = linkedId;
        Linked = linked;
    }

    public ObjectiveId MainId { get; set; }
    public Objective Main { get; set; } = null!;

    public KeyVariableId LinkedId { get; set; }
    public KeyVariable Linked { get; set; } = null!;
}
