using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureKindAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureKindAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureAggregate;

public class Feature : AbstractAuditableEntity<FeatureId, Guid>, IAggregateRoot<FeatureId, Guid>
{
    private Feature() : base(new FeatureId(default)) { }

    public Feature(FeatureId id, FeatureKindId kindId, string description, FeatureKind? kind = null) : base(id)
    {
        KindId = kindId;
        Description = description;
        Kind = kind;
    }

    public FeatureKind? Kind { get; set; }
    public FeatureKindId KindId { get; set; }

    public string Description { get; set; } = null!;
}
