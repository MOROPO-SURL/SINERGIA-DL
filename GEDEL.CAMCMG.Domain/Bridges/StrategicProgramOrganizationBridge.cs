using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Bridges;

public class StrategicProgramOrganizationBridge : IBridge<StrategicProgram, StrategicProgramId, Guid, Organization, OrganizationId, Guid>
{
    private StrategicProgramOrganizationBridge() { }

    public StrategicProgramOrganizationBridge(StrategicProgramId mainId, OrganizationId linkedId, StrategicProgram? main = null, Organization? linked = null)
    {
        MainId = mainId;
        Main = main;
        LinkedId = linkedId;
        Linked = linked;
    }

    public StrategicProgramId MainId { get; set; }
    public StrategicProgram? Main { get; set; }

    public OrganizationId LinkedId { get; set; }
    public Organization? Linked { get; set; }
}
