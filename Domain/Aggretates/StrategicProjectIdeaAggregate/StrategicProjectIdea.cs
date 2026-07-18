using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramProjectIdeaAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramProjectIdeaAggregate;

public class StrategicProjectIdea : AbstractAuditableEntity<StrategicProjectIdeaId, Guid>, IAggregateRoot<StrategicProjectIdeaId, Guid>, INamedEntity<StrategicProjectIdeaId, Guid>, IArchivableEntity<StrategicProjectIdeaId, Guid>, IEnableableEntity<StrategicProjectIdeaId, Guid>, IPriorizableEntity<StrategicProjectIdeaId, Guid>
{
    private StrategicProjectIdea() : base(new StrategicProjectIdeaId(default)) { }

    public StrategicProjectIdea(
        StrategicProjectIdeaId id, 
        StrategicProgramId programId, 
        string title, 
        int priority, 
        bool isArchived, 
        bool isEnabled, 
        StrategicProgram? program = null,
        string? description = null) : base(id)
    {
        ProgramId = programId;
        Name = title;
        Priority = priority;
        IsArchived = isArchived;
        IsEnabled = isEnabled;
        Description = description;
    }

    public StrategicProgramId ProgramId { get; set; }
    public StrategicProgram? Program { get; set; }

    public bool IsArchived { get; set; }

    public bool IsEnabled { get; set; }

    public int Priority { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}
