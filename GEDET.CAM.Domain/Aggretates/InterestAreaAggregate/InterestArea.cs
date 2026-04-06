using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;
using MOROPO.GEDET.CAM.Domain.Aggretates.InterestAreaAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Values;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.InterestAreaAggregate
{
    public class InterestArea : AbstractAuditableEntity<InterestAreaId>, IAggregateRoot<InterestAreaId>, IArchivableEntity<InterestAreaId>, IEnableableEntity<InterestAreaId>, INamedEntity<InterestAreaId>
    {
        private InterestArea() : base(new InterestAreaId(default)) { }

        public InterestArea(InterestAreaId id, string name, string? description, bool enabled, bool isArchived): base(id)
        {
            Name = name;
            Description = description;
            Enabled = enabled;
            IsArchived = isArchived;
        }

        public string Name { get ; set ; } = null!;

        public string? Description { get ; set ; }

        public bool Enabled { get ; set ; }
        
        public bool IsArchived { get ; set ; }
    }
}
