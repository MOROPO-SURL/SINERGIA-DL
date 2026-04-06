using MOROPO.GEDET.CAM.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.ImageAggregate;

public class Image : AbstractAuditableEntity<ImageId>, IAggregateRoot<ImageId>
{
    private Image () : base(new ImageId(default)) { }

    public Image(ImageId id, string contentType, long length, int height, int width, string? about) : base(id)
    {
        ContentType = contentType;
        Length = length;
        Height = height;
        Width = width;
        About = about;
    }

    public string ContentType { get; set; } = null!;

    public long Length { get; set; }

    public string? About { get; set; }

    public int Height { get; set; }

    public int Width { get; set; }
}
