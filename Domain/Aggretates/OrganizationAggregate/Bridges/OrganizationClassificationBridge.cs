using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClassificationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClassificationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Bridges;

public sealed class OrganizationClassificationBridge
{
    private OrganizationClassificationBridge() { }

    public OrganizationClassificationBridge(OrganizationId mainId, ClassificationId linkedId, Classification? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Linked = linked;
    }

    public OrganizationId MainId { get; set; }

    public ClassificationId LinkedId { get; set; }
    public Classification? Linked { get; set; }
}
