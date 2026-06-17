using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate;

public class StrategicLine : IAggregateRoot
{
    private readonly List<StrategicLineAction> strategicActions = [];
    private readonly List<StrategicLineOrganizationBridge> organizationBridges = [];

    private StrategicLine() { }

    public StrategicLine(StrategicLineId firstId, bool isEnabled, string name, bool isArchived, PersonId coordinatorId, string objective, StrategicLineAction[] strategicActions, StrategicLineOrganizationBridge[] organizationBridges, StrategicAxeId? secoundId = null, Person? coordinator = null, string? description = null, StrategicAxe? strategicAxe = null)
    {
        FirstId = firstId;
        SecoundId = secoundId;
        Description = description;
        IsEnabled = isEnabled;
        Name = name;
        IsArchived = isArchived;
        CoordinadorId = coordinatorId;
        Coordinator = coordinator;
        Objective = objective;
        StrategicAxe = strategicAxe;

        this.strategicActions = [.. strategicActions];
        this.organizationBridges = [.. organizationBridges];
    }

    public StrategicLineId FirstId { get; set; }
    public StrategicAxeId? SecoundId { get; set; }
    public StrategicAxe? StrategicAxe { get; set; }

    public bool IsEnabled { get; set; }

    public bool IsArchived { get; set; }

    public string Name { get; set; } = null!;

    public string Objective { get; set; } = null!;

    // TODO SpecigficObjective

    // TODO PublicPolicy Bridges !!

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; }

    public string? Description { get; set; }

    public Person? Coordinator { get; set; } = null!;
    public PersonId CoordinadorId { get; set; }

    // TODO Remove
    public IReadOnlyList<StrategicLineAction> StrategicActions => [.. strategicActions];

    public IReadOnlyList<StrategicLineOrganizationBridge> OrganizationBridges => [.. organizationBridges];
}
