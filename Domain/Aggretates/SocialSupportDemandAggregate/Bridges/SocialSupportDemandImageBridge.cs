using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ImageAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate.Bridges;

public sealed class SocialSupportDemandImageBridge
{
    private SocialSupportDemandImageBridge() { }

    public SocialSupportDemandImageBridge(SocialSupportDemandId mainId, ImageId linkedId, Image? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Linked = linked;
    }

    public SocialSupportDemandId MainId { get; set; }

    public ImageId LinkedId { get; set; }

    public Image? Linked { get; set; }
}
