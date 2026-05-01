using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritorialBarrierAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritorialBarrierAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;

public class TerritorialBarrierTrace : Abstractions.AbstractTrace<TerritorialBarrier, TerritorialBarrierId, Guid>
{
    private TerritorialBarrierTrace() { }

    public TerritorialBarrierTrace(TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, string signature, string? beforeData = null, string? afterData = null, TerritorialBarrierId? targetId = null, TerritorialBarrier? target = null) : base(id, kind, author, createAt, signature, beforeData, afterData, targetId, target)
    {
    }
}