using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate;

public class StrategicAxe :
    AbstractAuditableEntity<StrategicAxeId, int>, 
    IAggregateRoot<StrategicAxeId, int>, 
    IArchivableEntity<StrategicAxeId, int>,
    INamedEntity<StrategicAxeId, int>, 
    IEnableableEntity<StrategicAxeId, int>
{
    private StrategicAxe() : base(new StrategicAxeId(default)) { }

    public StrategicAxe(StrategicAxeId id, bool isArchived, string name, bool isEnabled, string? description = null) : base(id)
    {
        IsArchived = isArchived;
        Name = name;
        Description = description;
        IsEnabled = isEnabled;
    }

    public bool IsArchived { get; set; }

    public string Name { get; set; } = null!;

    public bool IsEnabled { get; set; }

    public string? Description { get; set; }
}
