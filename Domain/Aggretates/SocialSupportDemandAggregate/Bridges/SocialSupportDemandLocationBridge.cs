using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.LocationAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.LocationAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialSupportDemandAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialSupportDemandAggregate.Bridges;

public sealed class SocialSupportDemandLocationBridge
{
    private SocialSupportDemandLocationBridge() { }

    public SocialSupportDemandLocationBridge(SocialSupportDemandId mainId, LocationId linkedId, Location? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Linked = linked;
    }

    public SocialSupportDemandId MainId { get; set; }

    public LocationId LinkedId { get; set; }
    public Location? Linked { get; set; }
}
