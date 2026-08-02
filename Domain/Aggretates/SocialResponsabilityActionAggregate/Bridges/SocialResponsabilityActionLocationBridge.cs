using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.LocationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.LocationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Bridges;

public sealed class SocialResponsabilityActionLocationBridge
{
    private SocialResponsabilityActionLocationBridge() { }

    public SocialResponsabilityActionLocationBridge(SocialResponsabilityActionId mainId, LocationId linkedId, Location? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Linked = linked;
    }

    public SocialResponsabilityActionId MainId { get; set; }

    public LocationId LinkedId { get; set; }
    public Location? Linked { get; set; }
}