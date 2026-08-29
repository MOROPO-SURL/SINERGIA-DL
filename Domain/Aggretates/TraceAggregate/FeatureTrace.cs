using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;

public class FeatureTrace : Abstractions.AbstractTrace<Feature, FeatureId, Guid>
{
    private FeatureTrace() { }

    public FeatureTrace(TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, string signature, string? beforeData = null, string? afterData = null, FeatureId? targetId = null, Feature? target = null) : base(id, kind, author, createAt, signature, beforeData, afterData, targetId, target)
    {
    }
}