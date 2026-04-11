using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate;

public class StrategicProject : AbstractAuditableEntity<StrategicProjectId, Guid>, IAggregateRoot<StrategicProjectId, Guid>, INamedEntity<StrategicProjectId, Guid>, IArchivableEntity<StrategicProjectId, Guid>, IEnableableEntity<StrategicProjectId, Guid>, IPriorizableEntity<StrategicProjectId, Guid>
{
    private StrategicProject() : base(new StrategicProjectId(default)) { }

    public StrategicProject(StrategicProjectId id, StrategicProgramId programId, bool isEnabled, bool isArchived, string name, string? description = null, StrategicProgram? program = null) : base(id)
    {
        ProgramId = programId;
        IsEnabled = isEnabled;
        IsArchived = isArchived;
        Name = name;
        Description = description;

        Program = program;
    }

    public StrategicProgramId ProgramId { get; set; }
    public StrategicProgram? Program { get; set; } 

    public bool IsEnabled { get; set; }

    public bool IsArchived { get; set; }

    public int Priority { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}
