using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate;

public class StrategicProgram : AbstractAuditableEntity<StrategicProgramId, Guid>, IAggregateRoot<StrategicProgramId, Guid>, IArchivableEntity<StrategicProgramId, Guid>, INamedEntity<StrategicProgramId, Guid>, IEnableableEntity<StrategicProgramId, Guid>, IPriorizableEntity<StrategicProgramId, Guid>
{
    private readonly List<ProgramObjective> objetives = [];
    private readonly List<ProgramAction> actions = [];
    private readonly List<ProgramProjectIdea> projectIdeas = [];
    private readonly List<ProgramImpact> impacts = [];
    private readonly List<StrategicProgramOrganizationBridge> organizationBridges = [];
    private readonly List<StrategicProgramMacroprogramBridge> macroprogramBridges = [];

    private StrategicProgram() : base(new StrategicProgramId(default)) { }

    public StrategicProgram(
        StrategicProgramId id, 
        StrategicLineId lineId, 
        bool isEnabled, 
        string name, 
        bool isArchived, 
        int priority, 
        PersonId coordinatorId, 
        string objective, 
        ProgramAction[] actions, 
        ProgramProjectIdea[] projectIdeas, 
        StrategicProgramOrganizationBridge[] organizationBridges,
        StrategicProgramMacroprogramBridge[] macroprogramBridges,
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

        this.actions = [.. actions];
        this.projectIdeas = [.. projectIdeas];
        this.organizationBridges = [.. organizationBridges];
        this.macroprogramBridges = [.. macroprogramBridges];
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
    public IReadOnlyList<ProgramObjective> Objetives => [.. objetives];

    public IReadOnlyList<ProgramAction> Actions => [.. actions];
    // TODO Cada accion tiene indicadores y metas anuales

    public IReadOnlyList<ProgramProjectIdea> ProjectIdeas => [.. projectIdeas];

    // TODO Remove
    public IReadOnlyList<ProgramImpact> Impacts => [.. impacts];

    public IReadOnlyList<StrategicProgramOrganizationBridge> OrganizationBridges => [.. organizationBridges];

    public IReadOnlyList<StrategicProgramMacroprogramBridge> MacroprogramBridges => [.. macroprogramBridges];

    public void AddAction(ProgramAction entity)
    {
        actions.Add(entity);
    }

    public void RemoveAction(ProgramAction entity)
    {
        actions.Remove(actions.First(_entity => _entity.Id == entity.Id));
    }

    public void AddIdea(ProgramProjectIdea entity)
    {
        projectIdeas.Add(entity);
    }

    public void RemoveIdea(ProgramProjectIdea entity)
    {
        projectIdeas.Remove(projectIdeas.First(_entity => _entity.Id == entity.Id));
    }

    public void LinkOrganizationById(OrganizationId organizationId) => organizationBridges.Add(new StrategicProgramOrganizationBridge(Id, organizationId));

    public void UnlinkOrganizationById(OrganizationId organizationId) => organizationBridges.Remove(organizationBridges.First(bridge => bridge.LinkedId == organizationId));

    public void LinkMacroprogramById(MacroprogramId macroprogramId) => macroprogramBridges.Add(new StrategicProgramMacroprogramBridge(Id, macroprogramId));

    public void UnlinkMacroprogramById(MacroprogramId macroprogramId) => macroprogramBridges.Remove(macroprogramBridges.First(bridge => bridge.LinkedId == macroprogramId));
}
