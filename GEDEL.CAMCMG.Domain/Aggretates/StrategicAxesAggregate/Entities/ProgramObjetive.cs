using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Entities;

public class ProgramObjetive : AbstractAuditableEntity<ProgramObjetiveId, Guid>, INamedEntity<ProgramObjetiveId, Guid>, IArchivableEntity<ProgramObjetiveId, Guid>, IEnableableEntity<ProgramObjetiveId, Guid>
{
    private ProgramObjetive() : base(new ProgramObjetiveId(default)) { }

    public ProgramObjetive(ProgramObjetiveId id, StrategicProgramId strategicProgramId, StrategicLineId strategicLineId, StrategicAxesId strategicAxesId, bool isEnabled, bool isArchived, string name, string? description, int index) : base(id)
    {
        StrategicProgramId = strategicProgramId;
        StrategicLineId = strategicLineId;
        StrategicAxesId = strategicAxesId;
        IsEnabled = isEnabled;
        IsArchived = isArchived;
        Name = name;
        Description = description;
        Index = index;
    }

    public StrategicAxesId StrategicAxesId { get; set; }

    public StrategicLineId StrategicLineId { get; set; }

    public StrategicProgramId StrategicProgramId { get; set; }

    public bool IsEnabled { get; set; }

    public bool IsArchived { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int Index { get; set; }
}
