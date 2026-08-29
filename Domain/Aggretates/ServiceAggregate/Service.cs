using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ImageAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ServiceAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ServiceAggregate;

public sealed class Service : AbstractEntity<ServiceId, Guid>, IAggregateRoot<ServiceId, Guid>, IEnableableEntity<ServiceId, Guid>, IArchivableEntity<ServiceId, Guid>, IPriorizableEntity<ServiceId, Guid>, INamedEntity<ServiceId, Guid>
{
    private Service() : base(default) { }

    public Service(ServiceId id, string name, bool isEnabled, int priority, ImageId? imageId = null, Image? image = null, string? description = null) : base(id)
    {
        Name = name;
        IsEnabled = isEnabled;
        Priority = priority;
        ImageId = imageId;
        Image = image;
        Description = description;
    }

    public bool IsEnabled { get; set; }

    public bool IsArchived { get; set; } = false;

    public int Priority { get; set; }

    public string Name { get; set; } = null!;

    public ImageId? ImageId { get; set; }
    public Image? Image { get; set; }

    public string? Description { get; set; }
}
