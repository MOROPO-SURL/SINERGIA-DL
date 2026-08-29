using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.EconomicActivityAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.EconomicActivityAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;

public sealed class EconomicActivityTrace : Abstractions.AbstractTrace<EconomicActivity, EconomicActivityId, int>
{
    private EconomicActivityTrace() { }

    public EconomicActivityTrace(TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, string signature, string? beforeData = null, string? afterData = null, EconomicActivityId? targetId = null, EconomicActivity? target = null) : base(id, kind, author, createAt, signature, beforeData, afterData, targetId, target)
    {
    }
}