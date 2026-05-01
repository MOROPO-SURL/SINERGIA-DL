using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;

public class ObjectiveTrace : Abstractions.AbstractTrace<Objective, ObjectiveId, Guid>
{
    private ObjectiveTrace() { }

    public ObjectiveTrace(TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, string signature, string? beforeData = null, string? afterData = null, ObjectiveId? targetId = null, Objective? target = null) : base(id, kind, author, createAt, signature, beforeData, afterData, targetId, target)
    {
    }
}