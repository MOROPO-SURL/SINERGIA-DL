using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate;

public class StrategicLine : 
    AbstractAuditableEntity<StrategicLineId, Guid>,
    IAggregateRoot<StrategicLineId, Guid>,
    IArchivableEntity<StrategicLineId, Guid>,
    INamedEntity<StrategicLineId, Guid>,
    IEnableableEntity<StrategicLineId, Guid>
{
    private readonly List<StrategicLineAction> strategicActions = [];
    private readonly List<StrategicLineOrganizationBridge> organizationBridges = [];

    private StrategicLine() : base(new StrategicLineId(default)) { }

    public StrategicLine(StrategicLineId id, int index, bool isEnabled, string name, bool isArchived, PersonId coordinatorId, string objective, StrategicLineAction[] strategicActions, StrategicLineOrganizationBridge[] organizationBridges, StrategicAxeId? axeId = null, StrategicAxe? axe = null, Person? coordinator = null, string? description = null)
        : base(id)
    {
        Index = index;
        Description = description;
        IsEnabled = isEnabled;
        Name = name;
        IsArchived = isArchived;
        CoordinatorId = coordinatorId;
        Coordinator = coordinator;
        Objective = objective;
        AxeId = axeId;
        Axe = axe;

        this.strategicActions = [.. strategicActions];
        this.organizationBridges = [.. organizationBridges];
    }

    public int Index { get; set; }

    public StrategicAxeId? AxeId { get; set; }
    public StrategicAxe? Axe { get; set; }

    public bool IsEnabled { get; set; }

    public bool IsArchived { get; set; }

    public string Name { get; set; } = null!;

    public string Objective { get; set; } = null!;

    // TODO SpecigficObjective

    // TODO PublicPolicy Bridges !!

    public string? Description { get; set; }

    public Person? Coordinator { get; set; } = null!;
    public PersonId CoordinatorId { get; set; }

    // TODO Remove
    public IReadOnlyList<StrategicLineAction> StrategicActions => [.. strategicActions];

    public IReadOnlyList<StrategicLineOrganizationBridge> OrganizationBridges => [.. organizationBridges];
}
