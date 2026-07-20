using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Entities;

public class ProgramImpact : AbstractEntity<ProgramImpactId, Guid>, INamedEntity<ProgramImpactId, Guid>, IPriorizableEntity<ProgramImpactId, Guid>
{
    private ProgramImpact() : base(default) { }

    public ProgramImpact(
        ProgramImpactId id, 
        StrategicProgramId programId, string name, int priority, string? description = null) : base(id)
    {
        ProgramId = programId;
        Priority = priority;
        Name = name;
        Description = description;
    }

    public StrategicProgramId ProgramId { get; set; }

    public int Priority { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}
