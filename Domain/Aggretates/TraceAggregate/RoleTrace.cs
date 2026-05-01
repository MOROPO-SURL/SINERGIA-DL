using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.RoleAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;

public sealed class RoleTrace : Abstractions.AbstractTrace<RoleAggregate.Role, RoleId, Guid>
{
    private RoleTrace() { }

    public RoleTrace(TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, string signature, string? beforeData = null, string? afterData = null, RoleId? roleId = null, RoleAggregate.Role? role = null) : base(id, kind, author, createAt, signature, beforeData, afterData, roleId, role)
    {
    }
}