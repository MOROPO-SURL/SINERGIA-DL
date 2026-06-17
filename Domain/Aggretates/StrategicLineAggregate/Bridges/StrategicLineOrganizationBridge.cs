using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Bridges;

public class StrategicLineOrganizationBridge
{
    private StrategicLineOrganizationBridge() { }

    public StrategicLineOrganizationBridge(StrategicLineId strategicLineId, StrategicAxeId? strategicAxesId, OrganizationId linkedId, Organization? linked = null)
    {
        StrategicLineId = strategicLineId;
        StrategicAxesId = strategicAxesId;
        LinkedId = linkedId;
        Linked = linked;
    }

    public StrategicLineId StrategicLineId { get; set; }

    public StrategicAxeId? StrategicAxesId { get; set; }

    public OrganizationId LinkedId { get; set; }
    public Organization? Linked { get; set; }
}
