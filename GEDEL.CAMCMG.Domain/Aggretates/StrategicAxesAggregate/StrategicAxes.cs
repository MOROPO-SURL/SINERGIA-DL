using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate;

public class StrategicAxes :
    AbstractAuditableEntity<StrategicAxesId, Guid>, IAggregateRoot<StrategicAxesId, Guid>, IArchivableEntity<StrategicAxesId, Guid>,
    INamedEntity<StrategicAxesId, Guid>, IEnableableEntity<StrategicAxesId, Guid>
{
    private readonly List<StrategicLine> lines = [];

    private StrategicAxes() : base(new StrategicAxesId(default)) { }

    public StrategicAxes(StrategicAxesId id, bool isArchived, string name, int index, bool isEnabled, StrategicLine[] lines, string? description = null) : base(id)
    {
        IsArchived = isArchived;
        Name = name;
        Description = description;
        Index = index;
        IsEnabled = isEnabled;

        this.lines = [.. lines];
    }

    public bool IsArchived { get; set; }

    public string Name { get; set; } = null!;

    public int Index { get; set; }

    public bool IsEnabled { get; set; }

    public string? Description { get; set; }

    public StrategicLine[] Lines => [.. lines];
}
