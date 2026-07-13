using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ImageAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ProductAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ProductAggregate;

public sealed class Product : AbstractEntity<ProductId, Guid>, IAggregateRoot<ProductId, Guid>, IEnableableEntity<ProductId, Guid>, IArchivableEntity<ProductId, Guid>, IPriorizableEntity<ProductId, Guid>, INamedEntity<ProductId, Guid>
{
    private Product() : base(default) { }

    public Product(ProductId id, string name, bool isEnabled, int priority, string? description = null, ImageId? imageId = null, Image? image = null) : base(id)
    {
        Name = name;
        IsEnabled = isEnabled;
        Priority = priority;
        Description = description;
        ImageId = imageId;
        Image = image;
    }

    public bool IsEnabled { get; set; }

    public bool IsArchived { get; set; } = false;

    public int Priority { get; set; }

    public string Name { get; set; } = null!;

    public ImageId? ImageId { get; set; }
    public Image? Image { get; set; }

    public string? Description { get; set; }
}
