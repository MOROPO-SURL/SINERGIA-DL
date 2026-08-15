using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialResponsabilityActionAggregate;

public sealed class PDLSocialResponsabilityAction : AbstractSocialResponsabilityAction
{
    private PDLSocialResponsabilityAction() { }

    public PDLSocialResponsabilityAction(
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
        AbstractPDLDevelopmentActorProfile? owner = null) : base(id, ownerId, isArchived, title, at, locationBridges, imageBridges, demandId, demand, description)
    {
        Owner = owner;
    }

    public AbstractPDLDevelopmentActorProfile? Owner { get; set; }
}