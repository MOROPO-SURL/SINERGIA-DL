using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Bridges;

public sealed class SRLDevelopmentActorProfileOrganizationBridge
{
    private SRLDevelopmentActorProfileOrganizationBridge() { }

    public SRLDevelopmentActorProfileOrganizationBridge(DevelopmentActorProfileId mainId, OrganizationId linkedId, Organization? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Linked = linked;
    }

    public DevelopmentActorProfileId MainId { get; set; }

    public OrganizationId LinkedId { get; set; }
    public Organization? Linked { get; set; }
}