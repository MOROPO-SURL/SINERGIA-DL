using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Bridges;

public class StrategicLineOrganizationBridge : IBridge<StrategicLine, StrategicLineId, Guid, Organization, OrganizationId, Guid>
{
    private StrategicLineOrganizationBridge() { }

    public StrategicLineOrganizationBridge(StrategicLineId mainId, OrganizationId linkedId, StrategicLine? main = null, Organization? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Main = main;
        Linked = linked;
    }

    public StrategicLineId MainId { get; set; }
    public StrategicLine? Main { get; set; }

    public OrganizationId LinkedId { get; set; }
    public Organization? Linked { get; set; }
}
