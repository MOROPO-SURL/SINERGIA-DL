using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectIdeaAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectIdeaAggregate;

public class StrategicProjectIdea : AbstractAuditableEntity<StrategicProjectIdeaId, Guid>, IAggregateRoot<StrategicProjectIdeaId, Guid>, IArchivableEntity<StrategicProjectIdeaId, Guid>, IEnableableEntity<StrategicProjectIdeaId, Guid>, IPriorizableEntity<StrategicProjectIdeaId, Guid>
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
        Title = title;
        Priority = priority;
        IsArchived = isArchived;
        IsEnabled = isEnabled;
        Program = program;
        Description = description;
    }

    public StrategicProgramId ProgramId { get; set; }
    public StrategicProgram? Program { get; set; }

    public bool IsArchived { get; set; }

    public bool IsEnabled { get; set; }

    public int Priority { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }
}
