using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ImageAggregate;

public class Image : AbstractAuditableEntity<ImageId, Guid>, IAggregateRoot<ImageId, Guid>
{
    private Image() : base(default) { }

    public Image(ImageId id, string contentType, long length, int height, int width, string? about = null) : base(id)
    {
        ContentType = contentType;
        Length = length;
        About = about;
        Height = height;
        Width = width;
    }

    public string ContentType { get; set; } = null!;

    public long Length { get; set; }

    public string? About { get; set; }

    public int Height { get; set; }

    public int Width { get; set; }
}
