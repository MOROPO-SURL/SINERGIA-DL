using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Entities;

public class ProgramImpact : AbstractAuditableEntity<ProgramImpactId, Guid>, IAggregateRoot<ProgramImpactId, Guid>, INamedEntity<ProgramImpactId, Guid>, IArchivableEntity<ProgramImpactId, Guid>, IEnableableEntity<ProgramImpactId, Guid>
{
    private readonly List<ImpactIndicator> impactIndicators = [];

    private ProgramImpact() : base(new ProgramImpactId(default)) { }

    public ProgramImpact(ProgramImpactId id, StrategicProgramId strategicProgramId, StrategicLineId strategicLineId, StrategicAxesId strategicAxesId, bool isEnabled, bool isArchived, string name, ImpactIndicator[] impactIndicators, string? description = null) : base(id)
    {
        StrategicProgramId = strategicProgramId;
        StrategicLineId = strategicLineId;
        StrategicAxesId = strategicAxesId;
        IsEnabled = isEnabled;
        IsArchived = isArchived;
        Name = name;
        Description = description;

        this.impactIndicators = [.. impactIndicators];
    }

    public StrategicAxesId StrategicAxesId { get; set; }

    public StrategicLineId StrategicLineId { get; set; }

    public StrategicProgramId StrategicProgramId { get; set; }

    public bool IsEnabled { get; set; }

    public bool IsArchived { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public ImpactIndicator[] ImpactIndicator => [.. impactIndicators];
}
