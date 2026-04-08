using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClasificationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClasificationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Bridges;

public class OrganizationClasificationBridge : IBridge<Organization, OrganizationId, Guid, Clasification, ClasificationId, Guid>
{
    private OrganizationClasificationBridge() { }

    public OrganizationClasificationBridge(OrganizationId mainId, ClasificationId linkedId, Organization? main = null, Clasification? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Main = main;
        Linked = linked;
    }

    public OrganizationId MainId { get; set; }
    public Organization? Main { get; set; }

    public ClasificationId LinkedId { get; set; }
    public Clasification? Linked { get; set; }
}
