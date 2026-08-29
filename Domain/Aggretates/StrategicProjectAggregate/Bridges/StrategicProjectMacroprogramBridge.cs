using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectAggregate.Bridges;

public sealed class StrategicProjectMacroprogramBridge
{
    public StrategicProjectMacroprogramBridge() { }

    public StrategicProjectMacroprogramBridge (StrategicProjectId mainId, MacroprogramId linkedId, Macroprogram? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Linked = linked;
    }

    public StrategicProjectId MainId { get; set; }

    public MacroprogramId LinkedId { get; set; }
    public Macroprogram? Linked { get; set; }
}
