using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;

public class PublicPolicyTrace : Abstractions.AbstractTrace<PublicPolicy, PublicPolicyId, Guid>
{
    private PublicPolicyTrace() { }

    public PublicPolicyTrace(TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, string signature, string? beforeData = null, string? afterData = null, PublicPolicyId? targetId = null, PublicPolicy? target = null) : base(id, kind, author, createAt, signature, beforeData, afterData, targetId, target)
    {
    }
}