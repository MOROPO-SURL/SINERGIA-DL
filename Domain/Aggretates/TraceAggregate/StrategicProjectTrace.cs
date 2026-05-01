using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;

public class StrategicProjectTrace : Abstractions.AbstractTrace<StrategicProject, StrategicProjectId, Guid>
{
    private StrategicProjectTrace() { }

    public StrategicProjectTrace(TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, string signature, string? beforeData = null, string? afterData = null, StrategicProjectId? targetId = null, StrategicProject? target = null) : base(id, kind, author, createAt, signature, beforeData, afterData, targetId, target)
    {
    }
}