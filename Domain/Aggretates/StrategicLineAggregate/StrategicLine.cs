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

    public StrategicLine(StrategicLineId firstId, StrategicAxeId secoundId, bool isEnabled, string name, bool isArchived, PersonId coordinatorId, StrategicLineAction[] strategicActions, StrategicLineOrganizationBridge[] organizationBridges, Person? coordinator = null, string? description = null, StrategicAxe? strategicAxe = null)
    {
        FirstId = firstId;
        SecoundId = secoundId;
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

    public StrategicLineId FirstId { get; set; }
    public StrategicAxeId SecoundId { get; set; }
    public StrategicAxe? StrategicAxe { get; set; }

    public bool IsEnabled { get; set; }

    public bool IsArchived { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; }

    public string? Description { get; set; }

    public Person? Coordinator { get; set; } = null!;
    public PersonId CoordinadorId { get; set; }

    public IReadOnlyList<StrategicLineAction> StrategicActions => [.. strategicActions];

    public StrategicLineOrganizationBridge[] OrganizationBridges => [.. organizationBridges];
}
