using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Bridges;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Entities;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate;

public class StrategicProgram : AbstractAuditableEntity<StrategicProgramId, Guid>, IAggregateRoot<StrategicProgramId, Guid>, IArchivableEntity<StrategicProgramId, Guid>, INamedEntity<StrategicProgramId, Guid>, IEnableableEntity<StrategicProgramId, Guid>, IPriorizableEntity<StrategicProgramId, Guid>
{
    private readonly List<ProgramSpecificObjective> specificObjectives = [];
    private readonly List<ProgramAction> actions = [];
    private readonly List<ProgramImpact> impacts = [];
    private readonly List<StrategicProgramOrganizationBridge> organizationBridges = [];
    private readonly List<StrategicProgramMacroprogramBridge> macroprogramBridges = [];

    private StrategicProgram() : base(default) { }

    public StrategicProgram(
        StrategicProgramId id, 
        StrategicLineId lineId, 
        bool isEnabled, 
        string name, 
        bool isArchived, 
        int priority, 
        PersonId coordinatorId, 
        string objective,
        IEnumerable<ProgramSpecificObjective> specificObjectives,
        IEnumerable<ProgramAction> actions,
        IEnumerable<ProgramImpact> impacts,
        IEnumerable<StrategicProgramOrganizationBridge> organizationBridges,
        IEnumerable<StrategicProgramMacroprogramBridge> macroprogramBridges,
        StrategicLine? line = null, 
        Person? coordinator = null, 
        string? description = null) : base(id)
    {
        LineId = lineId;
        IsEnabled = isEnabled;
        Name = name;
        IsArchived = isArchived;
        Objective = objective;
        Description = description;
        Priority = priority;
        CoordinatorId = coordinatorId;
        Coordinator = coordinator;
        Line = line;
        this.specificObjectives = [.. specificObjectives];
        this.actions = [.. actions];
        this.impacts = [.. impacts];
        this.macroprogramBridges = [.. macroprogramBridges];
        this.organizationBridges = [.. organizationBridges];
    }

    public StrategicLineId LineId { get; set; }
    public StrategicLine? Line { get; set; }

    public bool IsEnabled { get; set; }

    public string Name { get; set; } = null!;

    public bool IsArchived { get; set; }

    public string Objective { get; set; } = null!;

    public string? Description { get; set; }

    public int Priority { get; set; }

    public Person? Coordinator { get; set; }
    public PersonId CoordinatorId { get; set; }

    // TODO Remove
    public IReadOnlyList<ProgramSpecificObjective> SpecificObjectives => [.. specificObjectives];

    public IReadOnlyList<ProgramAction> Actions => [.. actions];

    public IReadOnlyList<ProgramImpact> Impacts => [.. impacts];

    public IReadOnlyList<StrategicProgramOrganizationBridge> OrganizationBridges => [.. organizationBridges];

    public IReadOnlyList<StrategicProgramMacroprogramBridge> MacroprogramBridges => [.. macroprogramBridges];

    public void AddSpecificObjective(ProgramSpecificObjective entity)
    {
        specificObjectives.Add(entity);
    }

    public void RemoveSpecificObjective(ProgramSpecificObjective entity)
    {
        specificObjectives.Remove(specificObjectives.First(_entity => _entity.Id == entity.Id));
    }

    public void AddAction(ProgramAction entity)
    {
        actions.Add(entity);
    }

    public void RemoveAction(ProgramAction entity)
    {
        actions.Remove(actions.First(_entity => _entity.Id == entity.Id && _entity.ProgramId == entity.ProgramId));
    }

    public void AddImpact(ProgramImpact entity)
    {
        impacts.Add(entity);
    }

    public void RemoveImpact(ProgramImpact entity)
    {
        impacts.Remove(impacts.First(_entity => _entity.Id == entity.Id && _entity.ProgramId == entity.ProgramId));
    }

    public void LinkOrganizationById(OrganizationId organizationId) => organizationBridges.Add(new StrategicProgramOrganizationBridge(Id, organizationId));

    public void UnlinkOrganizationById(OrganizationId organizationId) => organizationBridges.Remove(organizationBridges.First(bridge => bridge.LinkedId == organizationId));

    public void LinkMacroprogramById(MacroprogramId macroprogramId) => macroprogramBridges.Add(new StrategicProgramMacroprogramBridge(Id, macroprogramId));

    public void UnlinkMacroprogramById(MacroprogramId macroprogramId) => macroprogramBridges.Remove(macroprogramBridges.First(bridge => bridge.LinkedId == macroprogramId));
}
