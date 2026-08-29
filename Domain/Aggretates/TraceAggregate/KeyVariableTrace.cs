using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.KeyVariableAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.KeyVariableAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;

public class KeyVariableTrace : Abstractions.AbstractTrace<KeyVariable, KeyVariableId, Guid>
{
    private KeyVariableTrace() { }

    public KeyVariableTrace(TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, string signature, string? beforeData = null, string? afterData = null, KeyVariableId? targetId = null, KeyVariable? target = null) : base(id, kind, author, createAt, signature, beforeData, afterData, targetId, target)
    {
    }
}