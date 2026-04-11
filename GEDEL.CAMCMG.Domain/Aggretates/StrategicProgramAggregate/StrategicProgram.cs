using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate;

public class StrategicProgram : AbstractAuditableEntity<StrategicProgramId, Guid>, IAggregateRoot<StrategicProgramId, Guid>, IArchivableEntity<StrategicProgramId, Guid>, INamedEntity<StrategicProgramId, Guid>, IEnableableEntity<StrategicProgramId, Guid>
{
    private readonly List<ProgramObjective> objetives = [];
    private readonly List<ProgramAction> actions = [];
    private readonly List<ProgramProjectIdea> projectIdeas = [];
    private readonly List<ProgramImpact> impacts = [];
    private readonly List<StrategicProgramOrganizationBridge> organizationBridges = [];


    private StrategicProgram() : base(new StrategicProgramId(default)) { }

    public StrategicProgram(StrategicProgramId id, StrategicLineId strategicLineId, StrategicAxeId strategicAxesId, bool isEnabled, string name, bool isArchived, int index, PersonId coordinatorId, ProgramObjective[] objetives, ProgramAction[] actions, ProgramProjectIdea[] projectIdeas, ProgramImpact[] impacts, StrategicProgramOrganizationBridge[] organizationBridges, Person? coordinator = null, string? description = null) : base(id)
    {
        StrategicLineId = strategicLineId;
        StrategicAxeId = strategicAxesId;
        IsEnabled = isEnabled;
        Name = name;
        IsArchived = isArchived;
        Description = description;
        Index = index;
        CoordinatorId = coordinatorId;
        Coordinator = coordinator;

        this.objetives = [.. objetives];
        this.actions = [.. actions];
        this.projectIdeas = [.. projectIdeas];
        this.impacts = [.. impacts];
        this.organizationBridges = [.. organizationBridges];
    }

    public StrategicAxeId StrategicAxeId { get; set; }
    public StrategicLineId StrategicLineId { get; set; }
    public StrategicLine? StrategicLine { get; set; }

    public bool IsEnabled { get; set; }

    public string Name { get; set; } = null!;

    public bool IsArchived { get; set; }

    public string? Description { get; set; }

    public int Index { get; set; }

    public Person? Coordinator { get; set; }
    public PersonId CoordinatorId { get; set; } // TODO Put on ORM configuration !!!

    public ProgramObjective[] Objetives => [.. objetives];

    public ProgramAction[] Actions => [.. actions];

    public ProgramProjectIdea[] ProjectIdeas => [.. projectIdeas];

    public ProgramImpact[] Impacts => [.. impacts];

    public StrategicProgramOrganizationBridge[] OrganizationBridges => [.. organizationBridges];
}
