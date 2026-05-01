using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClassificationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClassificationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;

public class ClassificationTrace : Abstractions.AbstractTrace<Classification, ClassificationId, Guid>
{
    private ClassificationTrace() { }

    public ClassificationTrace(TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, string signature, string? beforeData = null, string? afterData = null, ClassificationId? targetId = null, Classification? target = null) : base(id, kind, author, createAt, signature, beforeData, afterData, targetId, target)
    {
    }
}