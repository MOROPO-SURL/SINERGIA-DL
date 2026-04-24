using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.FeatureKindAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.FeatureKindAggregate;

public class FeatureKind : AbstractEntity<FeatureKindId, Guid>, IAggregateRoot<FeatureKindId, Guid>, IEnableableEntity<FeatureKindId, Guid>, IPriorizableEntity<FeatureKindId, Guid>, INamedEntity<FeatureKindId, Guid>
{
    private FeatureKind() : base(new FeatureKindId(default)) { }

    public FeatureKind(FeatureKindId id, bool isEnabled, int priority, string name, string? description = null) : base(id)
    {
        IsEnabled = isEnabled;
        Priority = priority;
        Name = name;
        Description = description;
    }

    public bool IsEnabled { get; set; }

    public int Priority { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}
