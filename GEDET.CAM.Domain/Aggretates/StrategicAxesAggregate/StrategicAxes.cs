using MOROPO.GEDET.CAM.Domain.Aggretates.ObjectiveAggregate.Entities;
using MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Entities;
using MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;-*

namespace MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate
{
    public class StrategicAxes : 
        AbstractAuditableEntity<StrategicAxesId>, IAggregateRoot<StrategicAxesId>, IArchivableEntity<StrategicAxesId>, 
        INamedEntity<StrategicAxesId>, IEnableableEntity<StrategicAxesId>
    {
        private readonly List<StrategicLine> lines = [];

        private StrategicAxes() : base(new StrategicAxesId(default)) { }

        public StrategicAxes(StrategicAxesId id, bool isArchived, string name, string? description, int index, bool enabled, StrategicLine[] lines) : base(id)
        {
            IsArchived = isArchived;
            Name = name;
            Description = description;
            Index = index;
            Enabled = enabled;

            this.lines = [.. lines];
        }

        public bool IsArchived { get ; set ; }

        public string Name { get ; set ; } = null!;

        public string? Description { get ; set ; }

        public int Index { get ; set ; }

        public bool Enabled { get ; set ; }

        public StrategicLine[] Lines => [.. lines];

    }
}
