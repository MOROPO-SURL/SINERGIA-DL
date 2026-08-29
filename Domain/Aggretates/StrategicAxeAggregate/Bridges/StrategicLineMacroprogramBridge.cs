using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicAxeAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate.Bridges;

public sealed class StrategicAxeMacroprogramBridge
{
    public StrategicAxeMacroprogramBridge() { }

    public StrategicAxeMacroprogramBridge(StrategicAxeId mainId, MacroprogramId linkedId, Macroprogram? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Linked = linked;
    }

    public StrategicAxeId MainId { get; set; }

    public MacroprogramId LinkedId { get; set; }
    public Macroprogram? Linked { get; set; }
}
