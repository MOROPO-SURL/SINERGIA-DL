using MOROPO.GEDET.CAM.Domain.Aggretates.KeyVariableAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.KeyVariableAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.ObjectiveAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.ObjectiveAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Bridges;

public class ObjectiveKeyVariableBridge : IBridge<Objective, ObjectiveId, Guid, KeyVariable, KeyVariableId, Guid>
{
    private ObjectiveKeyVariableBridge() { }

    public ObjectiveKeyVariableBridge(ObjectiveId mainId, KeyVariableId linkedId)
    {
        MainId = mainId;
        LinkedId = linkedId;
    }

    public ObjectiveId MainId { get; set; }
    public Objective? Main { get; set; }

    public KeyVariableId LinkedId { get; set; }
    public KeyVariable? Linked { get; set; }
}