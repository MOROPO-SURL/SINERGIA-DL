using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Bridges;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialSupportDemandAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialSupportDemandAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialResponsabilityActionAggregate;

public sealed class SRLSocialResponsabilityAction : AbstractSocialResponsabilityAction
{
    private SRLSocialResponsabilityAction() { }

    public SRLSocialResponsabilityAction(
        SocialResponsabilityActionId id, 
        DevelopmentActorProfileId ownerId, 
        bool isArchived,
        string title, 
        DateTime at,  
        IEnumerable<SocialResponsabilityActionLocationBridge> locationBridges, 
        IEnumerable<SocialResponsabilityActionImageBridge> imageBridges, 
        SocialSupportDemandId? demandId = null, 
        SocialSupportDemand? demand = null, 
        string? description = null,
        SRLDevelopmentActorProfile? owner = null) : base(id, ownerId, isArchived, title, at, locationBridges, imageBridges, demandId, demand, description)
    {
        Owner = owner;
    }

    public SRLDevelopmentActorProfile? Owner { get; set; }
}