using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.LocationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Abstractions;

public abstract class AbstractSocialResponsabilityAction : AbstractEntity<SocialResponsabilityActionId, Guid>, IAggregateRoot<SocialResponsabilityActionId, Guid>, IArchivableEntity<SocialResponsabilityActionId, Guid>
{
    protected readonly List<Bridges.SocialResponsabilityActionLocationBridge> locationBridges = [];
    protected readonly List<Bridges.SocialResponsabilityActionImageBridge> imageBridges = [];

    internal protected AbstractSocialResponsabilityAction() : base(default) { }

    protected AbstractSocialResponsabilityAction(SocialResponsabilityActionId id, DevelopmentActorProfileId ownerId, bool isArchived, string title, DateTime at, IEnumerable<Bridges.SocialResponsabilityActionLocationBridge> locationBridges, IEnumerable<Bridges.SocialResponsabilityActionImageBridge> imageBridges, SocialSupportDemandId? demandId = null, SocialSupportDemand? demand = null, string? description = null) : base(id)
    {
        OwnerId = ownerId;
        IsArchived = isArchived;
        Title = title;
        At = at;
        DemandId = demandId;
        Demand = demand;
        Description = description;

        this.locationBridges = [.. locationBridges];
        this.imageBridges = [.. imageBridges];
    }

    public DevelopmentActorProfileId OwnerId { get; set; }

    public bool IsArchived { get; set; }

    public string Title { get; set; } = null!;

    public DateTime At { get; set; }

    public SocialSupportDemandId? DemandId { get; set; } 
    public SocialSupportDemand? Demand { get; set; }

    public string? Description { get; set; }

    public IReadOnlyList<Bridges.SocialResponsabilityActionLocationBridge> LocationBridges => [.. locationBridges];

    public IReadOnlyList<Bridges.SocialResponsabilityActionImageBridge> ImageBridges => [.. imageBridges];

    public void LinkLocationById(LocationId locationId) => locationBridges.Add(new Bridges.SocialResponsabilityActionLocationBridge(Id, locationId));

    public void RemoveLocationBridge(Bridges.SocialResponsabilityActionLocationBridge bridge) => locationBridges.Remove(bridge);

    public void LinkImageById(ImageId imageId) => imageBridges.Add(new Bridges.SocialResponsabilityActionImageBridge(Id, imageId));

    public void RemoveImageBridge(Bridges.SocialResponsabilityActionImageBridge bridge) => imageBridges.Remove(bridge);
}
