using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.LocationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate;

public sealed class SocialSupportDemand : AbstractEntity<SocialSupportDemandId, Guid>, IAggregateRoot<SocialSupportDemandId, Guid>, IEnableableEntity<SocialSupportDemandId, Guid>, IArchivableEntity<SocialSupportDemandId, Guid>, IPriorizableEntity<SocialSupportDemandId, Guid>
{
    private readonly List<Bridges.SocialSupportDemandLocationBridge> locationBridges = [];
    private readonly List<Bridges.SocialSupportDemandImageBridge> imageBridges = [];

    private SocialSupportDemand() : base(default) { }

    public SocialSupportDemand(SocialSupportDemandId id, string title, int priority, bool isEnabled, bool isArchived, IEnumerable<Bridges.SocialSupportDemandLocationBridge> locationBridges, IEnumerable<Bridges.SocialSupportDemandImageBridge> imageBridges, DateTime? startAt = null, DateTime? endAt = null, string? description = null) : base(id)
    {
        Title = title;
        Priority = priority;
        IsEnabled = isEnabled;
        IsArchived = isArchived;
        StartAt = startAt;
        EndAt = endAt;
        Description = description;

        this.locationBridges = [.. locationBridges];
        this.imageBridges = [.. imageBridges];
    }

    public string Title { get; set; } = null!;

    public int Priority { get; set; }

    public bool IsArchived { get; set; }

    public bool IsEnabled { get; set; }

    public DateTime? StartAt { get; set; }

    public DateTime? EndAt { get; set; }

    public string? Description { get; set; }

    public IReadOnlyList<Bridges.SocialSupportDemandLocationBridge> LocationBridges => [.. locationBridges];

    public IReadOnlyList<Bridges.SocialSupportDemandImageBridge> ImageBridges => [.. imageBridges];

    public void LinkLocationById(LocationId locationId) => locationBridges.Add(new Bridges.SocialSupportDemandLocationBridge(Id, locationId));

    public void RemoveLocationBridge(Bridges.SocialSupportDemandLocationBridge bridge) => locationBridges.Remove(bridge);

    public void LinkImageById(ImageId imageId) => imageBridges.Add(new Bridges.SocialSupportDemandImageBridge(Id, imageId));

    public void RemoveImageBridge(Bridges.SocialSupportDemandImageBridge bridge) => imageBridges.Remove(bridge);
}
