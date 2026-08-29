using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate.Bridges;

public class StrategicLineOrganizationBridge
{
    private StrategicLineOrganizationBridge() { }

    public StrategicLineOrganizationBridge(StrategicLineId mainId, OrganizationId linkedId, Organization? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Linked = linked;
    }

    public StrategicLineId MainId { get; set; }

    public OrganizationId LinkedId { get; set; }
    public Organization? Linked { get; set; }
}