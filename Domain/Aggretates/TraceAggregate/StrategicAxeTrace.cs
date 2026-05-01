using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;

public class StrategicAxeTrace : Abstractions.AbstractTrace<StrategicAxe, StrategicAxeId, int>
{
    private StrategicAxeTrace() { }

    public StrategicAxeTrace(TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, string signature, string? beforeData = null, string? afterData = null, StrategicAxeId? targetId = null, StrategicAxe? target = null) : base(id, kind, author, createAt, signature, beforeData, afterData, targetId, target)
    {
    }
}