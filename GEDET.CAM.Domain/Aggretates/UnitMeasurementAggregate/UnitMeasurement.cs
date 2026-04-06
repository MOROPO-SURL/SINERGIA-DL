using MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.UnitMeasurementAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.UnitMeasurementAggregate
{
    public class UnitMeasurement : AbstractAuditableEntity<UnitMeasurementId>, IAggregateRoot<UnitMeasurementId>, INamedEntity<UnitMeasurementId>, IArchivableEntity<UnitMeasurementId>, IEnableableEntity<UnitMeasurementId>
    {
        private UnitMeasurement() : base(new UnitMeasurementId(default)) { }

        public UnitMeasurement(UnitMeasurementId id, bool enabled, bool isArchived, string name, string symbol, bool prefixed): base(id)
        {
            Enabled = enabled;
            IsArchived = isArchived;
            Name = name;
            Symbol = symbol;
            Prefixed = prefixed;
        }

        public bool Enabled { get ; set ; }

        public bool IsArchived { get ; set ; }
        
        public string Name { get ; set ; } = null!;

        public string Symbol { get ; set ; } = null!;

        public bool Prefixed { get ; set ; }
    }
}
