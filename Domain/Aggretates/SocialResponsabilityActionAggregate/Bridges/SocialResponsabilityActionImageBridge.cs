using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ImageAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Bridges;

public sealed class SocialResponsabilityActionImageBridge
{
    private SocialResponsabilityActionImageBridge() { }

    public SocialResponsabilityActionImageBridge(SocialResponsabilityActionId mainId, ImageId linkedId, Image? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Linked = linked;
    }

    public SocialResponsabilityActionId MainId { get; set; }

    public ImageId LinkedId { get; set; }

    public Image? Linked { get; set; }
}