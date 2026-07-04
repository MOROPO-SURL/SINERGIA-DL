using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Bridges;

public sealed class DevelopmentActorProfileEconomicActivityBridge
{
    private DevelopmentActorProfileEconomicActivityBridge() { }

    public DevelopmentActorProfileEconomicActivityBridge(DevelopmentActorProfileId mainId, EconomicActivityId linkedId, EconomicActivity? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Linked = linked;
    }
    public DevelopmentActorProfileId MainId { get; set; }

    public EconomicActivityId LinkedId { get; set; }
    public EconomicActivity? Linked { get; set; }
}
