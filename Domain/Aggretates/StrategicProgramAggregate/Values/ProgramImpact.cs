using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;

public class ProgramImpact : AbstractAuditableEntity<ProgramImpactId, Guid>, IAggregateRoot<ProgramImpactId, Guid>, INamedEntity<ProgramImpactId, Guid>, IArchivableEntity<ProgramImpactId, Guid>, IEnableableEntity<ProgramImpactId, Guid>, IPriorizableEntity<ProgramImpactId, Guid>
{
    private readonly List<ImpactIndicator> impactIndicators = [];

    private ProgramImpact() : base(new ProgramImpactId(default)) { }

    public ProgramImpact(ProgramImpactId id, StrategicProgramId strategicProgramId, bool isEnabled, bool isArchived, int priority, string name, ImpactIndicator[] impactIndicators, string? description = null) : base(id)
    {
        StrategicProgramId = strategicProgramId;
        IsEnabled = isEnabled;
        IsArchived = isArchived;
        Priority = priority;
        Name = name;
        Description = description;

        this.impactIndicators = [.. impactIndicators];
    }

    public StrategicProgramId StrategicProgramId { get; set; }

    public bool IsEnabled { get; set; }

    public bool IsArchived { get; set; }

    public int Priority { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public ImpactIndicator[] ImpactIndicator => [.. impactIndicators];
}
