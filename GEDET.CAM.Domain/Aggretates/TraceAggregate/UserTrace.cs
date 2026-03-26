using MOROPO.GEDET.CAM.Domain.Common.Ports.Service;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.TraceAggregate;

public sealed class UserTrace : Abstractions.AbstractTrace<UserAggregate.User, UserAggregate.UserId>
{
    public UserTrace(IDataIntegrityServicePort dataIntegrityService, TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, UserAggregate.User user, UserAggregate.UserId userId, string? beforeData, string? afterData) : base(dataIntegrityService, id, kind, author, createAt, user, userId, beforeData, afterData)
    {
    }
}