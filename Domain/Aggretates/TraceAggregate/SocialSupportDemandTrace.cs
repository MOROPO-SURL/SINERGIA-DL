using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;

public sealed class SocialSupportDemandTrace : Abstractions.AbstractTrace<SocialSupportDemand, SocialSupportDemandId, Guid>
{
    private SocialSupportDemandTrace() { }

    public SocialSupportDemandTrace(TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, string signature, string? beforeData = null, string? afterData = null, SocialSupportDemandId? targetId = null, SocialSupportDemand? target = null) : base(id, kind, author, createAt, signature, beforeData, afterData, targetId, target)
    {
    }
}