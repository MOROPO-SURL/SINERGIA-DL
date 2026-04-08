using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Entities;

public class ProgramExecutionProject : AbstractAuditableEntity<ProgramExecutionProjectId, Guid>, INamedEntity<ProgramExecutionProjectId, Guid>, IArchivableEntity<ProgramExecutionProjectId, Guid>, IEnableableEntity<ProgramExecutionProjectId, Guid>
{
    private ProgramExecutionProject() : base(new ProgramExecutionProjectId(default)) { }

    public ProgramExecutionProject(ProgramExecutionProjectId id, StrategicProgramId strategicProgramId, StrategicLineId strategicLineId, StrategicAxesId strategicAxesId, bool isEnabled, bool isArchived, string name, string? description = null) : base(id)
    {
        StrategicProgramId = strategicProgramId;
        StrategicLineId = strategicLineId;
        StrategicAxesId = strategicAxesId;
        IsEnabled = isEnabled;
        IsArchived = isArchived;
        Name = name;
        Description = description;
    }

    public StrategicAxesId StrategicAxesId { get; set; }

    public StrategicLineId StrategicLineId { get; set; }

    public StrategicProgramId StrategicProgramId { get; set; }

    public bool IsEnabled { get; set; }

    public bool IsArchived { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public List<ProgramExecutionProyectProgramObjetiveBridge> ProgramObjetiveBridges { get; set; } = [];
}
