using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectKindAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectKindAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate;

public class StrategicProject : AbstractAuditableEntity<StrategicProjectId, Guid>, IAggregateRoot<StrategicProjectId, Guid>, INamedEntity<StrategicProjectId, Guid>, IArchivableEntity<StrategicProjectId, Guid>, IEnableableEntity<StrategicProjectId, Guid>, IPriorizableEntity<StrategicProjectId, Guid>
{
    private StrategicProject() : base(new StrategicProjectId(default)) { }

    public StrategicProject(StrategicProjectId id, StrategicProjectKindId kindId, StrategicProgramId programId, bool isEnabled, bool isArchived, string name,int priority, string? description = null, StrategicProjectKind? kind = null, StrategicProgram? program = null) : base(id)
    {
        KindId = kindId;
        ProgramId = programId;
        IsEnabled = isEnabled;
        IsArchived = isArchived;
        Name = name;
        Description = description;
        Priority = priority;
        Kind = kind;
        Program = program;
    }

    public StrategicProjectKindId KindId { get; set; }
    public StrategicProjectKind? Kind { get; set; }

    public StrategicProgramId ProgramId { get; set; }
    public StrategicProgram? Program { get; set; } 

    public bool IsEnabled { get; set; }

    public bool IsArchived { get; set; }

    public int Priority { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}
