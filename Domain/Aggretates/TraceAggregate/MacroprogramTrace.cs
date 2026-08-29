using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;

public class MacroprogramTrace : Abstractions.AbstractTrace<Macroprogram, MacroprogramId, Guid>
{
    private MacroprogramTrace() { }

    public MacroprogramTrace(TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, string signature, string? beforeData = null, string? afterData = null, MacroprogramId? targetId = null, Macroprogram? target = null) : base(id, kind, author, createAt, signature, beforeData, afterData, targetId, target)
    {
    }
}