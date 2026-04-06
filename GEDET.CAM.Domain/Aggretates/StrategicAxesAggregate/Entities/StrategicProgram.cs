using MOROPO.GEDET.CAM.Domain.Aggretates.PersonAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Bridges;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Entities
{
    public class StrategicProgram : AbstractAuditableEntity<StrategicProgramId>, IAggregateRoot<StrategicProgramId>, IArchivableEntity<StrategicProgramId>, INamedEntity<StrategicProgramId>, IEnableableEntity<StrategicProgramId>
    {
        private readonly List<ProgramAction> programActions = [];
        private readonly List<ProgramIdeaProyect> programIdeaProyects = [];
        private readonly List<ProgramExecutionProyect> programExecutionProyects = [];
        private readonly List<ProgramObjetive> programObjetives = [];
        private readonly List<ProgramImpact> programImpacts = [];


        private StrategicProgram() : base(new StrategicProgramId(default)) { }

        public StrategicProgram(StrategicProgramId id, bool enabled, string name, bool isArchived, string? description, int index, Person coordinator, ProgramAction[] programActions, ProgramIdeaProyect[] programIdeaProyects, ProgramExecutionProyect[] programExecutionProyects, ProgramObjetive[] programObjetives, ProgramImpact[] programImpacts, StrategicProgramOrganizationBridge[] organizationBridges): base(id)
        {
            Enabled = enabled;
            Name = name;
            IsArchived = isArchived;
            Description = description;
            Index = index;
            Coordinator = coordinator;

            this.programActions = [.. programActions];
            this.programIdeaProyects = [.. programIdeaProyects];
            this.programExecutionProyects = [.. programExecutionProyects];
            this.programObjetives = [.. programObjetives];
            this.programImpacts = [.. programImpacts];

            OrganizationBridges = [.. organizationBridges];
        }

        public StrategicAxesId StrategicAxesId { get; set; }

        public StrategicLineId StrategicLineId { get; set; }

        public bool Enabled { get ; set ; }
       
        public string Name { get ; set ; } = null!;

        public bool IsArchived { get ; set ; }

        public string? Description { get ; set ; }

        public int Index { get ; set ; }

        public PersonAggregate.Person Coordinator { get ; set ; } = null!;

        public ProgramAction[] ProgramActions => [.. programActions];

        public ProgramIdeaProyect[] ProgramIdeaProyect => [.. programIdeaProyects];

        public ProgramExecutionProyect[] ProgramExecutionProyect => [.. programExecutionProyects];

        public ProgramObjetive[] ProgramObjetive => [.. programObjetives];

        public ProgramImpact[] ProgramImpact => [.. programImpacts];

        public List<StrategicProgramOrganizationBridge> OrganizationBridges {  get; set; } = null!;
    }
}
