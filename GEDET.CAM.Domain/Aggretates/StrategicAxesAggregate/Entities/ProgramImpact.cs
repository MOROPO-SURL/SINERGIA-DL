using MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Entities
{
    public class ProgramImpact : AbstractAuditableEntity<ProgramImpactId>, IAggregateRoot<ProgramImpactId>, INamedEntity<ProgramImpactId>, IArchivableEntity<ProgramImpactId>, IEnableableEntity<ProgramImpactId>
    {
        private readonly List<ImpactIndicator> impactIndicators = [];

        private ProgramImpact() : base(new ProgramImpactId(default)) { }

        public ProgramImpact(ProgramImpactId id, bool enabled, bool isArchived, string name, string? description, ImpactIndicator[] impactIndicators) : base(id)
        {
            Enabled = enabled;
            IsArchived = isArchived;
            Name = name;
            Description = description;

            this.impactIndicators = [.. impactIndicators];
        }

        public StrategicAxesId StrategicAxesId { get; set; }

        public StrategicLineId StrategicLineId { get; set; }

        public StrategicProgramId StrategicProgramId { get; set; }

        public bool Enabled { get ; set ; }

        public bool IsArchived { get ; set ; }
        
        public string Name { get ; set ; } = null!;

        public string? Description { get ; set ; }

        public ImpactIndicator[] ImpactIndicator => [.. impactIndicators];
    }
}
