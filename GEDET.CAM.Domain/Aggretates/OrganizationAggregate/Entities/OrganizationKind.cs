using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate.Entities
{
    public class OrganizationKind : AbstractAuditableEntity<OrganizationKindId>, IPriorizableEntity<OrganizationKindId>, IArchivableEntity<OrganizationKindId>, IEnableableEntity<OrganizationKindId>, INamedEntity<OrganizationKindId>
    {
        private OrganizationKind() : base(new OrganizationKindId(default)) { }

        public OrganizationKind(OrganizationKindId id, bool enabled, bool isArchived, int priority, string name, string description): base(id)
        {
            Enabled = enabled;
            IsArchived = isArchived;
            Priority = priority;
            Name = name;
            Description = description;
        }

        public OrganizationId OrganizationId { get; set; }

        public bool Enabled { get ; set ; }

        public bool IsArchived { get ; set ; }
        
        public int Priority { get ; set ; }

        public string Name { get; set; } = null!;

        public string? Description { get ; set ; }
    }
}
