using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;

public class InterestAreaTrace : Abstractions.AbstractTrace<InterestArea, InterestAreaId, Guid>
{
    private InterestAreaTrace() { }

    public InterestAreaTrace(TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, string signature, string? beforeData = null, string? afterData = null, InterestAreaId? targetId = null, InterestArea? target = null) : base(id, kind, author, createAt, signature, beforeData, afterData, targetId, target)
    {
    }
}