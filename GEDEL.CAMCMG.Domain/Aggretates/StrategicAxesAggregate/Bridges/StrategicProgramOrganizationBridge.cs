using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Bridges;

public class StrategicProgramOrganizationBridge
{
    private StrategicProgramOrganizationBridge() { }

    public StrategicProgramOrganizationBridge(StrategicProgramId strategicProgramId, StrategicAxesId strategicAxesId, StrategicLineId strategicLineId, OrganizationId linkedId, Organization? linked = null)
    {
        StrategicProgramId = strategicProgramId;
        StrategicAxesId = strategicAxesId;
        StrategicLineId = strategicLineId;
        LinkedId = linkedId;
        Linked = linked;
    }

    public StrategicProgramId StrategicProgramId { get; set; }

    public StrategicAxesId StrategicAxesId { get; set; }

    public StrategicLineId StrategicLineId { get; set; }

    public OrganizationId LinkedId { get; set; }
    public Organization? Linked { get; set; }
}
