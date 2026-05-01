using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationKindAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationKindAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;

public class OrganizationKindTrace : Abstractions.AbstractTrace<OrganizationKind, OrganizationKindId, Guid>
{
    private OrganizationKindTrace() { }

    public OrganizationKindTrace(TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, string signature, string? beforeData = null, string? afterData = null, OrganizationKindId? targetId = null, OrganizationKind? target = null) : base(id, kind, author, createAt, signature, beforeData, afterData, targetId, target)
    {
    }
}