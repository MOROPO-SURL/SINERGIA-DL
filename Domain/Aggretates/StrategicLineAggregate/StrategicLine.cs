using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate.Values;
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
    private readonly List<StrategicLineSpecificObjective> specificObjectives = [];
    private readonly List<StrategicLineOrganizationBridge> organizationBridges = [];
    private readonly List<StrategicLinePublicPolicyBridge> publicPolicyBridges = [];
    private readonly List<StrategicLineMacroprogramBridge> macroprogramBridges = [];

    private StrategicLine() : base(new StrategicLineId(default)) { }

    public StrategicLine(StrategicLineId id, int index, bool isEnabled, string name, bool isArchived, PersonId coordinatorId, string objective, StrategicLineSpecificObjective[] specificObjectives, StrategicLineAction[] strategicActions, StrategicLineOrganizationBridge[] organizationBridges, StrategicLinePublicPolicyBridge[] publicPolicyBridges, StrategicLineMacroprogramBridge[] macroprogramBridges, StrategicAxeId? axeId = null, StrategicAxe? axe = null, Person? coordinator = null, string? description = null)
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

        this.specificObjectives = [.. specificObjectives];
        this.strategicActions = [.. strategicActions];
        this.organizationBridges = [.. organizationBridges];
        this.publicPolicyBridges = [.. publicPolicyBridges];
        this.macroprogramBridges = [.. macroprogramBridges];
    }

    public int Index { get; set; }

    public StrategicAxeId? AxeId { get; set; }
    public StrategicAxe? Axe { get; set; }

    public bool IsEnabled { get; set; }

    public bool IsArchived { get; set; }

    public string Name { get; set; } = null!;

    public string Objective { get; set; } = null!;

    public string? Description { get; set; }

    public Person? Coordinator { get; set; } = null!;
    public PersonId CoordinatorId { get; set; }

    public IReadOnlyList<StrategicLineSpecificObjective> SpecificObjectives => [.. specificObjectives];

    // TODO Remove
    public IReadOnlyList<StrategicLineAction> StrategicActions => [.. strategicActions];

    public IReadOnlyList<StrategicLineOrganizationBridge> OrganizationBridges => [.. organizationBridges];

    public IReadOnlyList<StrategicLinePublicPolicyBridge> PublicPolicyBridges => [.. publicPolicyBridges];

    public IReadOnlyList<StrategicLineMacroprogramBridge> MacroprogramBridges => [.. macroprogramBridges];

    public void AddSpecificObjective(StrategicLineSpecificObjective entity) => specificObjectives.Add(entity);

    public void RemoveSpecificObjective(StrategicLineSpecificObjective entity) => specificObjectives.Remove(entity);

    public void LinkOrganizationById(OrganizationId organizationId) => organizationBridges.Add(new StrategicLineOrganizationBridge(Id, organizationId));

    public void UnlinkOrganizationById(OrganizationId organizationId) => organizationBridges.Remove(organizationBridges.First(bridge => bridge.LinkedId == organizationId));

    public void LinkPublicPolicyById(PublicPolicyId publicPolicyId) => publicPolicyBridges.Add(new StrategicLinePublicPolicyBridge(Id, publicPolicyId));

    public void UnlinkPublicPolicy(PublicPolicyId publicPolicyId) => publicPolicyBridges.Remove(publicPolicyBridges.First(bridge => bridge.LinkedId == publicPolicyId));

    public void LinkMacroprogramById(MacroprogramId macroprogramId) => macroprogramBridges.Add(new StrategicLineMacroprogramBridge(Id, macroprogramId));

    public void UnlinkMacroprogramById(MacroprogramId macroprogramId) => macroprogramBridges.Remove(macroprogramBridges.First(bridge => bridge.LinkedId == macroprogramId));
}
