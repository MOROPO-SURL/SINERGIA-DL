using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;

public class TerritoryPotentialTrace : Abstractions.AbstractTrace<TerritoryPotential, TerritoryPotentialId, Guid>
{
    private TerritoryPotentialTrace() { }

    public TerritoryPotentialTrace(TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, string signature, string? beforeData = null, string? afterData = null, TerritoryPotentialId? targetId = null, TerritoryPotential? target = null) : base(id, kind, author, createAt, signature, beforeData, afterData, targetId, target)
    {
    }
}