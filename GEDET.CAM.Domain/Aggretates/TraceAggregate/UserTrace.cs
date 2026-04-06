using MOROPO.GEDET.CAM.Domain.Aggretates.TraceAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate.Values;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.TraceAggregate;

public sealed class UserTrace : Abstractions.AbstractTrace<UserAggregate.User, UserId, string>
{
    public UserTrace(TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, UserAggregate.User user, UserId userId, string signature, string? beforeData, string? afterData) : base(id, kind, author, createAt, user, userId, signature, beforeData, afterData)
    {
    }
}