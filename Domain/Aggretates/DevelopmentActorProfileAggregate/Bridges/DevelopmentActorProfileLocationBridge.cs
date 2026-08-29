using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.LocationAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.LocationAggregate;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Bridges;

public sealed class DevelopmentActorProfileLocationBridge
{
    private DevelopmentActorProfileLocationBridge() { }

    public DevelopmentActorProfileLocationBridge(DevelopmentActorProfileId mainId, LocationId linkedId, Location? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Linked = linked;
    }
    public DevelopmentActorProfileId MainId { get; set; }

    public LocationId LinkedId { get; set; }
    public Location? Linked { get; set; }
}