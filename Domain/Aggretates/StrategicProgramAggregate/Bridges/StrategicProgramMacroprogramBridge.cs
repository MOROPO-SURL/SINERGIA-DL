using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Bridges;

public sealed class StrategicProgramMacroprogramBridge
{
    public StrategicProgramMacroprogramBridge() { }

    public StrategicProgramMacroprogramBridge(StrategicProgramId mainId, MacroprogramId linkedId, Macroprogram? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Linked = linked;
    }

    public StrategicProgramId MainId { get; set; }

    public MacroprogramId LinkedId { get; set; }
    public Macroprogram? Linked { get; set; }
}