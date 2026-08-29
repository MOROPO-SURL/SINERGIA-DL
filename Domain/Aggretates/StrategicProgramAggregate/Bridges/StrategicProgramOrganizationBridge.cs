using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Bridges;

public class StrategicProgramOrganizationBridge
{
    private StrategicProgramOrganizationBridge() { }

    public StrategicProgramOrganizationBridge(StrategicProgramId mainId, OrganizationId linkedId, Organization? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Linked = linked;
    }

    public StrategicProgramId MainId { get; set; }

    public OrganizationId LinkedId { get; set; }
    public Organization? Linked { get; set; }
}
