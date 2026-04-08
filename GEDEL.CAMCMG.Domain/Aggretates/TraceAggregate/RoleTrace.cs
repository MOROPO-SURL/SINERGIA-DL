using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.RoleAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;

public sealed class RoleTrace : Abstractions.AbstractTrace<RoleAggregate.Role, RoleId, Guid>
{
    public RoleTrace(TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, RoleAggregate.Role role, RoleId roleId, string signature, string? beforeData, string? afterData) : base(id, kind, author, createAt, role, roleId, signature, beforeData, afterData)
    {
    }
}