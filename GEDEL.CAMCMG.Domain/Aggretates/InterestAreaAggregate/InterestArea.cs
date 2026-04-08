using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate;

public class InterestArea : AbstractAuditableEntity<InterestAreaId, Guid>, IAggregateRoot<InterestAreaId, Guid>, IArchivableEntity<InterestAreaId, Guid>, IEnableableEntity<InterestAreaId, Guid>, INamedEntity<InterestAreaId, Guid>
{
    private InterestArea() : base(new InterestAreaId(default)) { }

    public InterestArea(InterestAreaId id, string name, bool isEnabled, bool isArchived, string? description = null) : base(id)
    {
        Name = name;
        Description = description;
        IsEnabled = isEnabled;
        IsArchived = isArchived;
    }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsEnabled { get; set; }

    public bool IsArchived { get; set; }
}
