using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Bridges;
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

    private StrategicProgram() : base(new StrategicProgramId(default)) { }

    public StrategicProgram(StrategicProgramId id, StrategicLineId lineId, bool isEnabled, string name, bool isArchived, int priority, PersonId coordinatorId, string objective, ProgramObjective[] objetives, ProgramAction[] actions, ProgramProjectIdea[] projectIdeas, ProgramImpact[] impacts, StrategicProgramOrganizationBridge[] organizationBridges, StrategicLine? line = null, Person? coordinator = null, string? description = null) : base(id)
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

        this.objetives = [.. objetives];
        this.actions = [.. actions];
        this.projectIdeas = [.. projectIdeas];
        this.impacts = [.. impacts];
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
    public IReadOnlyList<ProgramObjective> Objetives => [.. objetives];

    public IReadOnlyList<ProgramAction> Actions => [.. actions];
    // TODO Cada accion tiene indicadores y metas anuales

    // TODO Remove
    public IReadOnlyList<ProgramProjectIdea> ProjectIdeas => [.. projectIdeas];

    // TODO Remove
    public IReadOnlyList<ProgramImpact> Impacts => [.. impacts];

    public IReadOnlyList<StrategicProgramOrganizationBridge> OrganizationBridges => [.. organizationBridges];

    public void AddObjective(ProgramObjective entity)
    {
        objetives.Add(entity);
    }

    public void RemoveObjective(ProgramObjective entity)
    {
        objetives.Remove(objetives.First(_entity => _entity.Id == entity.Id));
    }

    public void AddAction(ProgramAction entity)
    {
        actions.Add(entity);
    }

    public void RemoveAction(ProgramAction entity)
    {
        actions.Remove(actions.First(_entity => _entity.Id == entity.Id));
    }
}
