using MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Bridges;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Entities
{
    public class ProgramExecutionProyect : AbstractAuditableEntity<ProgramExecutionProyectId>, INamedEntity<ProgramExecutionProyectId>, IArchivableEntity<ProgramExecutionProyectId>, IEnableableEntity<ProgramExecutionProyectId>
    {
        private ProgramExecutionProyect() : base(new ProgramExecutionProyectId(default)) { }

        public ProgramExecutionProyect(ProgramExecutionProyectId id, bool enabled, bool isArchived, string name, string? description, ProgramExecutionProyectProgramObjetiveBridge[] programObjetiveBridges): base(id)
        {
            Enabled = enabled;
            IsArchived = isArchived;
            Name = name;
            Description = description;
            ProgramObjetiveBridges = [.. programObjetiveBridges];
        }

        public StrategicAxesId StrategicAxesId { get; set; }

        public StrategicLineId StrategicLineId { get; set; }

        public StrategicProgramId StrategicProgramId { get; set; }

        public bool Enabled { get ; set ; }

        public bool IsArchived { get ; set ; }
        
        public string Name { get ; set ; } = null!;

        public string? Description { get ; set ; }

        public List<ProgramExecutionProyectProgramObjetiveBridge> ProgramObjetiveBridges { get; set; } = null!;
    }
}
