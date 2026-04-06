using MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Entities
{
    public class ProgramIdeaProyect : AbstractAuditableEntity<ProgramIdeaProyectId>, INamedEntity<ProgramIdeaProyectId>, IArchivableEntity<ProgramIdeaProyectId>, IEnableableEntity<ProgramIdeaProyectId>
    {
        private ProgramIdeaProyect() : base(new ProgramIdeaProyectId(default)) { }

        public ProgramIdeaProyect(ProgramIdeaProyectId id, string name, string? description, bool isArchived, bool enabled): base(id)
        {
            Name = name;
            Description = description;
            IsArchived = isArchived;
            Enabled = enabled;
        }

        public StrategicAxesId StrategicAxesId { get; set; }

        public StrategicLineId StrategicLineId { get; set; }

        public StrategicProgramId StrategicProgramId { get; set; }

        public string Name { get ; set ; } = null!;

        public string? Description { get ; set ; }

        public bool IsArchived { get ; set ; }

        public bool Enabled { get ; set ; }
    }

}
