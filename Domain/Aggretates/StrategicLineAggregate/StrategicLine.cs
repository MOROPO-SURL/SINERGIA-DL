using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Values;
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

    public StrategicLine(StrategicLineId strategicLineId, StrategicAxeId strategicAxeId, bool isEnabled, string name, bool isArchived, PersonId coordinatorId, StrategicLineAction[] strategicActions, StrategicLineOrganizationBridge[] organizationBridges, Person? coordinator = null, string? description = null, StrategicAxe? strategicAxe = null)
    {
        StrategicLineId = strategicLineId;
        StrategicAxeId = strategicAxeId;
        Description = description;
        IsEnabled = isEnabled;
        Name = name;
        IsArchived = isArchived;
        CoordinadorId = coordinatorId;
        Coordinator = coordinator;
        StrategicAxe = strategicAxe;

        this.strategicActions = [.. strategicActions];
        this.organizationBridges = [.. organizationBridges];
    }

    public StrategicLineId StrategicLineId { get; set; }

    public StrategicAxeId StrategicAxeId { get; set; }
    public StrategicAxe? StrategicAxe { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; }

    public bool IsEnabled { get; set; }

    public bool IsArchived { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public Person? Coordinator { get; set; } = null!;
    public PersonId CoordinadorId { get; set; }

    public StrategicLineAction[] StrategicActions => [.. strategicActions];

    public StrategicLineOrganizationBridge[] OrganizationBridges => [.. organizationBridges];
}
