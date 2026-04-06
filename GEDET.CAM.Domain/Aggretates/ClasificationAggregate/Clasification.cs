using MOROPO.GEDET.CAM.Domain.Aggretates.ClasificationAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.ClasificationAggregate
{
    public class Clasification : AbstractAuditableEntity<ClasificationId>, IAggregateRoot<ClasificationId>, IArchivableEntity<ClasificationId>, IEnableableEntity<ClasificationId>, INamedEntity<ClasificationId>, IPriorizableEntity<ClasificationId>
    {
        private Clasification() : base(new ClasificationId(default)) { }

        public Clasification(ClasificationId id, int priority, string name, string? description, bool enabled, bool isArchived): base(id)
        {
            Priority = priority;
            Name = name;
            Description = description;
            Enabled = enabled;
            IsArchived = isArchived;
        }

        public int Priority { get ; set ; }

        public string Name { get ; set ; } = null!;

        public string? Description { get ; set ; }
        
        public bool Enabled { get ; set ; }
        
        public bool IsArchived { get ; set ; }
    }
}
