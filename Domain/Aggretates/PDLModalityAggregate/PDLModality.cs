using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PDLModalityAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PDLModalityAggregate;

public sealed class PDLModality : AbstractEntity<PDLModalityId, Guid>, IAggregateRoot<PDLModalityId, Guid>, IEnableableEntity<PDLModalityId, Guid>, IArchivableEntity<PDLModalityId, Guid>, INamedEntity<PDLModalityId, Guid>, IPriorizableEntity<PDLModalityId, Guid>
{
    public PDLModality(PDLModalityId id, string name, bool isArchived, bool isEnabled, int priority, string? description = null) : base(id)
    {
        Name = name;
        IsArchived = isArchived;
        IsEnabled = isEnabled;
        Priority = priority;
        Description = description;
    }

    public string Name { get; set; }

    public bool IsArchived { get; set; }

    public bool IsEnabled { get; set; }

    public int Priority { get; set; }

    public string? Description { get; set; }
}