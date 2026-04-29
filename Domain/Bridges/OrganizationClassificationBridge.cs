using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClassificationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClassificationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Bridges;

public class OrganizationClassificationBridge : IBridge<Organization, OrganizationId, Guid, Classification, ClassificationId, Guid>
{
    private OrganizationClassificationBridge() { }

    public OrganizationClassificationBridge(OrganizationId mainId, ClassificationId linkedId, Organization? main = null, Classification? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Main = main;
        Linked = linked;
    }

    public OrganizationId MainId { get; set; }
    public Organization? Main { get; set; }

    public ClassificationId LinkedId { get; set; }
    public Classification? Linked { get; set; }
}
