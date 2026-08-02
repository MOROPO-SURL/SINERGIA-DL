using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ImageAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.LocationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.LocationAggregate;

public sealed class Location : AbstractEntity<LocationId, Guid>, IAggregateRoot<LocationId, Guid>, INamedEntity<LocationId, Guid>
{
    private Location() : base(default) { }

    public Location(LocationId id, string name, PostalAddress postalAddress, Coordinate coordinate, ImageId? featureImageId = null, Image? featureImage = null, string? description = null) : base(id)
    {
        Name = name;
        PostalAddress = postalAddress;
        Coordinate = coordinate;
        FeatureImageId = featureImageId;
        FeatureImage = featureImage;
        Description = description;
    }

    public string Name { get; set; } = null!;

    public PostalAddress PostalAddress { get; set; } = null!;

    public Coordinate Coordinate { get; set; } = null!;

    public ImageId? FeatureImageId { get; set; }
    public Image? FeatureImage { get; set; }

    public string? Description { get; set; }
}
