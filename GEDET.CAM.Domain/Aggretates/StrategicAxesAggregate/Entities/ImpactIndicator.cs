using MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.UnitMeasurementAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.UnitMeasurementAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Entities
{
    public class ImpactIndicator : AbstractAuditableEntity<ImpactIndicatorId>, INamedEntity<ImpactIndicatorId>, IArchivableEntity<ImpactIndicatorId>, IEnableableEntity<ImpactIndicatorId>
    {
        private ImpactIndicator() : base(new ImpactIndicatorId(default)) { }

        public ImpactIndicator(ImpactIndicatorId id, bool enabled, bool isArchived, string name, string alias, float meta, UnitMeasurement unitMeasurement): base(id)
        {
            Enabled = enabled;
            IsArchived = isArchived;
            Name = name;
            Alias = alias;
            Meta = meta;
            UnitMeasurement = unitMeasurement;
        }

        public StrategicAxesId StrategicAxesId { get; set; }

        public StrategicLineId StrategicLineId { get; set; }

        public StrategicProgramId StrategicProgramId { get; set; }

        public ProgramImpactId ProgramImpactId { get; set; }

        public bool Enabled { get ; set ; }

        public bool IsArchived { get ; set ; }
        
        public string Name { get ; set ; } = null!;

        public string Alias { get ; set ; } = null!;

        public float Meta { get ; set ; }

        public UnitMeasurement UnitMeasurement { get ; set ; } = null!;
        public UnitMeasurementId UnitMeasurementId { get; set; }

    }
}
