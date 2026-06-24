using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Bridges;

public sealed class StrategicLinePublicPolicyBridge
{
    public StrategicLinePublicPolicyBridge() { }

    public StrategicLinePublicPolicyBridge(StrategicLineId mainId, PublicPolicyId linkedId, PublicPolicy? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Linked = linked;
    }

    public StrategicLineId MainId { get; set; }

    public PublicPolicyId LinkedId { get; set; }
    public PublicPolicy? Linked { get; set; }
}
