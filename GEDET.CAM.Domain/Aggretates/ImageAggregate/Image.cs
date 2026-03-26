using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Contract;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.ImageAggregate;

public class Image : AbstractAuditableEntity<ImageId>, IAggregateRoot
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
