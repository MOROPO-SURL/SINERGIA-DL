using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Entities
{
    public class StrategicProgram : AbstractAuditableEntity<StrategicProgramId, Guid>, IAggregateRoot<StrategicProgramId, Guid>, IArchivableEntity<StrategicProgramId, Guid>, INamedEntity<StrategicProgramId, Guid>, IEnableableEntity<StrategicProgramId, Guid>
    {
        private readonly List<ProgramAction> programActions = [];
        private readonly List<ProgramIdeaProject> programIdeaProjects = [];
        private readonly List<ProgramExecutionProject> programExecutionProjects = [];
        private readonly List<ProgramObjetive> programObjetives = [];
        private readonly List<ProgramImpact> programImpacts = [];
        private readonly List<StrategicProgramOrganizationBridge> organizationBridges = [];


        private StrategicProgram() : base(new StrategicProgramId(default)) { }

        public StrategicProgram(StrategicProgramId id, StrategicLineId strategicLineId, StrategicAxesId strategicAxesId, bool isEnabled, string name, bool isArchived, int index, PersonId coordinatorId, ProgramAction[] programActions, ProgramIdeaProject[] programIdeaProyects, ProgramExecutionProject[] programExecutionProyects, ProgramObjetive[] programObjetives, ProgramImpact[] programImpacts, StrategicProgramOrganizationBridge[] organizationBridges, Person? coordinator = null, string? description = null) : base(id)
        {
            StrategicLineId = strategicLineId;
            StrategicAxesId = strategicAxesId;
            IsEnabled = isEnabled;
            Name = name;
            IsArchived = isArchived;
            Description = description;
            Index = index;
            CoordinatorId = coordinatorId;
            Coordinator = coordinator;

            this.programActions = [.. programActions];
            this.programIdeaProjects = [.. programIdeaProyects];
            this.programExecutionProjects = [.. programExecutionProyects];
            this.programObjetives = [.. programObjetives];
            this.programImpacts = [.. programImpacts];
            this.organizationBridges = [.. organizationBridges];
        }

        public StrategicAxesId StrategicAxesId { get; set; }

        public StrategicLineId StrategicLineId { get; set; }

        public bool IsEnabled { get; set; }

        public string Name { get; set; } = null!;

        public bool IsArchived { get; set; }

        public string? Description { get; set; }

        public int Index { get; set; }

        public Person? Coordinator { get; set; }
        public PersonId CoordinatorId { get; set; } // TODO Put on ORM configuration !!!

        public ProgramAction[] ProgramActions => [.. programActions];

        public ProgramIdeaProject[] ProgramIdeaProjects => [.. programIdeaProjects];

        public ProgramExecutionProject[] ProgramExecutionProjects => [.. programExecutionProjects];

        public ProgramObjetive[] ProgramObjetives => [.. programObjetives];

        public ProgramImpact[] ProgramImpacts => [.. programImpacts];

        public List<StrategicProgramOrganizationBridge> OrganizationBridges => [.. organizationBridges];
    }
}
