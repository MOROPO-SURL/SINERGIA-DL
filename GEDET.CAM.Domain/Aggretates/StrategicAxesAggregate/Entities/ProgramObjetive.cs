using MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Entities
{
    public class ProgramObjetive : AbstractAuditableEntity<ProgramObjetiveId>, INamedEntity<ProgramObjetiveId>, IArchivableEntity<ProgramObjetiveId>, IEnableableEntity<ProgramObjetiveId>
    {
        private ProgramObjetive() : base(new ProgramObjetiveId(default)) { }

        public ProgramObjetive(ProgramObjetiveId id, bool enabled, bool isArchived, string name, string? description, int index): base(id)
        {
            Enabled = enabled;
            IsArchived = isArchived;
            Name = name;
            Description = description;
            Index = index;
        }

        public StrategicAxesId StrategicAxesId { get; set; }

        public StrategicLineId StrategicLineId { get; set; }

        public StrategicProgramId StrategicProgramId { get; set; }

        public bool Enabled { get ; set ; }

        public bool IsArchived { get ; set ; }
        
        public string Name { get ; set ; } = null!;

        public string? Description { get ; set ; }

        public int Index { get ; set ; }
    }
}
