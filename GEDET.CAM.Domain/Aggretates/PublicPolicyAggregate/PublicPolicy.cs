using MOROPO.GEDET.CAM.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.PublicPolicyAggregate.Enumerations;
using MOROPO.GEDET.CAM.Domain.Aggretates.PublicPolicyAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.PublicPolicyAggregate
{
    public class PublicPolicy : AbstractAuditableEntity<PublicPolicyId>, IAggregateRoot<PublicPolicyId>, IArchivableEntity<PublicPolicyId>
    {
        private PublicPolicy() : base(new PublicPolicyId(default)) { }

        public PublicPolicy(PublicPolicyId id, bool isArchived, string title, string? description, DateTime publisheAt, PublicPolicyKind kind): base(id)
        {
            IsArchived = isArchived;
            Title = title;
            Description = description;
            PublisheAt = publisheAt;
            Kind = kind;
        }

        public bool IsArchived { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime PublisheAt { get; set; }

        public PublicPolicyKind Kind { get; set; }
    }
}
