using MOROPO.GEDET.CAM.Domain.Common.Ports.Service;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.TraceAggregate;

public sealed class RoleTrace : Abstractions.AbstractTrace<RoleAggregate.Role, RoleAggregate.RoleId>
{
    public RoleTrace(IDataIntegrityServicePort dataIntegrityService, TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, RoleAggregate.Role role, RoleAggregate.RoleId roleId, string? beforeData, string? afterData) : base(dataIntegrityService, id, kind, author, createAt, role, roleId, beforeData, afterData)
    {
    }
}
