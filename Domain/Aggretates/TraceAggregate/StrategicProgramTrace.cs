using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;

public class StrategicProgramTrace : Abstractions.AbstractTrace<StrategicProgram, StrategicProgramId, Guid>
{
    private StrategicProgramTrace() { }

    public StrategicProgramTrace(TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, string signature, string? beforeData = null, string? afterData = null, StrategicProgramId? targetId = null, StrategicProgram? target = null) : base(id, kind, author, createAt, signature, beforeData, afterData, targetId, target)
    {
    }
}