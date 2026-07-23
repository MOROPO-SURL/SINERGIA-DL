using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate;

public sealed class SocialSupportDemand : AbstractEntity<SocialSupportDemandId, Guid>, IAggregateRoot<SocialSupportDemandId, Guid>, IPriorizableEntity<SocialSupportDemandId, Guid>
{
    private readonly List<Entities.Location> locations = [];
    private readonly List<Bridges.SocialSupportDemandImageBridge> imageBridges = [];

    private SocialSupportDemand() : base(default) { }

    public SocialSupportDemand(SocialSupportDemandId id, string title, int priority, IEnumerable<Entities.Location> locations, IEnumerable<Bridges.SocialSupportDemandImageBridge> imageBridges, DateTime? startAt = null, DateTime? endAt = null, string? description = null) : base(id)
    {
        Title = title;
        Priority = priority;
        this.locations = [.. locations];
        this.imageBridges = [.. imageBridges];
        StartAt = startAt;
        EndAt = endAt;
        Description = description;
    }

    public string Title { get; set; } = null!;

    public int Priority { get; set; }

    public DateTime? StartAt { get; set; }

    public DateTime? EndAt { get; set; }

    public string? Description { get; set; }

    public IReadOnlyList<Entities.Location> Locations => [.. locations];

    public IReadOnlyList<Bridges.SocialSupportDemandImageBridge> ImageBridges => [.. imageBridges];

    public void AddLocation(Entities.Location entity) => locations.Add(entity);

    public void RemoveLocationById(LocationId locationId) => locations.Remove(locations.First(entity => entity.Id == locationId));

    public void LinkImageById(ImageId imageId) => imageBridges.Add(new Bridges.SocialSupportDemandImageBridge(Id, imageId));

    public void UnlinkImageById(ImageId imageId) => imageBridges.Remove(imageBridges.First(bridge => bridge.LinkedId == imageId));
}
