using MOROPO.GEDET.CAM.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.ImageAggregate;

public class Image : AbstractAuditableEntity<ImageId>, IAggregateRoot<ImageId>
{
    public Image(ImageId id, string contentType, long length, string? about, int height, int width) : base(id)
    {
        ContentType = contentType;
        Length = length;
        About = about;
        Height = height;
        Width = width;
    }

    public string ContentType { get; set; }

    public long Length { get; set; }

    public string? About { get; set; }

    public int Height { get; set; }

    public int Width { get; set; }
}
