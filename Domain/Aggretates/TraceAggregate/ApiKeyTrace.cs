using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ApiKeyAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ApiKeyAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;

public class ApiKeyTrace : Abstractions.AbstractTrace<ApiKey, ApiKeyId, Guid>
{
    private ApiKeyTrace() { }

    public ApiKeyTrace(TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, string signature, string? beforeData = null, string? afterData = null, ApiKeyId? targetId = null, ApiKey? target = null) : base(id, kind, author, createAt, signature, beforeData, afterData, targetId, target)
    {
    }
}