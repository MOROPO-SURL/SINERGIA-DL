using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Entities;

public class StrategicLine : AbstractAuditableEntity<StrategicLineId, Guid>, IAggregateRoot<StrategicLineId, Guid>, IArchivableEntity<StrategicLineId, Guid>, INamedEntity<StrategicLineId, Guid>, IEnableableEntity<StrategicLineId, Guid>
{
    private readonly List<StrategicAction> strategicActions = [];
    private readonly List<StrategicProgram> strategicPrograms = [];
    private readonly List<StrategicLineOrganizationBridge> organizationBridges = [];

    private StrategicLine() : base(new StrategicLineId(default)) { }

    public StrategicLine(StrategicLineId id, StrategicAxesId strategicAxesId, int index, bool isEnabled, string name, bool isArchived, PersonId coordinatorId, StrategicAction[] strategicActions, StrategicProgram[] strategicPrograms, StrategicLineOrganizationBridge[] organizationBridges, Person? coordinator = null, string? description = null) : base(id)
    {
        StrategicAxesId = strategicAxesId;
        Description = description;
        Index = index;
        IsEnabled = isEnabled;
        Name = name;
        IsArchived = isArchived;
        CoordinadorId = coordinatorId;
        Coordinator = coordinator;

        this.strategicActions = [.. strategicActions];
        this.strategicPrograms = [.. strategicPrograms];
        this.organizationBridges = [.. organizationBridges];
    }

    public StrategicAxesId StrategicAxesId { get; set; }

    public string? Description { get; set; }

    public int Index { get; set; }

    public bool IsEnabled { get; set; }

    public string Name { get; set; } = null!;

    public bool IsArchived { get; set; }

    public Person? Coordinator { get; set; } = null!;
    public PersonId CoordinadorId { get; set; }

    public StrategicAction[] StrategicActions => [.. strategicActions];

    public StrategicProgram[] StrategicProgram => [.. strategicPrograms];

    public StrategicLineOrganizationBridge[] OrganizationBridges => [.. organizationBridges];
}
