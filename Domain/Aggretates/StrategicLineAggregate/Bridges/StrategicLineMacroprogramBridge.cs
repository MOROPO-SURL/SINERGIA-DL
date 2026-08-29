using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate.Bridges;

public sealed class StrategicLineMacroprogramBridge
{
    public StrategicLineMacroprogramBridge() { }

    public StrategicLineMacroprogramBridge(StrategicLineId mainId, MacroprogramId linkedId, Macroprogram? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Linked = linked;
    }

    public StrategicLineId MainId { get; set; }

    public MacroprogramId LinkedId { get; set; }
    public Macroprogram? Linked { get; set; }
}