using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Entities;

public class ProgramProjectIdea : AbstractAuditableEntity<ProgramProjectIdeaId, Guid>, INamedEntity<ProgramProjectIdeaId, Guid>, IArchivableEntity<ProgramProjectIdeaId, Guid>, IEnableableEntity<ProgramProjectIdeaId, Guid>, IPriorizableEntity<ProgramProjectIdeaId, Guid>
{
    private ProgramProjectIdea() : base(new ProgramProjectIdeaId(default)) { }

    public ProgramProjectIdea(ProgramProjectIdeaId id, StrategicProgramId strategicProgramId, string name, int priority, bool isArchived, bool isEnabled, string? description = null) : base(id)
    {
        StrategicProgramId = strategicProgramId;
        Name = name;
        Priority = priority;
        IsArchived = isArchived;
        IsEnabled = isEnabled;
        Description = description;
    }

    public StrategicProgramId StrategicProgramId { get; set; }

    public bool IsArchived { get; set; }

    public bool IsEnabled { get; set; }

    public int Priority { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}
