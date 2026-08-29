using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PublicPolicyAggregate.Enumerations;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PublicPolicyAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PublicPolicyAggregate
{
    public class PublicPolicy : AbstractAuditableEntity<PublicPolicyId, Guid>, IAggregateRoot<PublicPolicyId, Guid>, IArchivableEntity<PublicPolicyId, Guid>
    {
        private PublicPolicy() : base(new PublicPolicyId(default)) { }

        public PublicPolicy(PublicPolicyId id, bool isArchived, string title, DateTime publisheAt, PublicPolicyKind kind, string? description = null) : base(id)
        {
            IsArchived = isArchived;
            Title = title;
            PublishedAt = publisheAt;
            Kind = kind;
            Description = description;
        }

        public bool IsArchived { get; set; }

        public string Title { get; set; } = null!;

        public DateTime PublishedAt { get; set; }

        public PublicPolicyKind Kind { get; set; }

        public string? Description { get; set; }
    }
}
