using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.TraceAggregate;

public sealed class RoleTrace : Abstractions.AbstractTrace<RoleAggregate.Role, RoleId>
{
    public RoleTrace(TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, RoleAggregate.Role role, RoleId roleId, string signature, string? beforeData, string? afterData) : base(id, kind, author, createAt, role, roleId, signature, beforeData, afterData)
    {
    }
}
