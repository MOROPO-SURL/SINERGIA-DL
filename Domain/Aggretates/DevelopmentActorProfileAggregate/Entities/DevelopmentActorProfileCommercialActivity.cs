using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ProductAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ProductAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Entities;

public sealed class DevelopmentActorProfileCommercialActivity : AbstractEntity<DevelopmentActorProfileCommercialActivityId, Guid>
{
    private DevelopmentActorProfileCommercialActivity() : base(default) { }

    public DevelopmentActorProfileCommercialActivity(DevelopmentActorProfileCommercialActivityId id) : base(id)
    {
    }

    public DevelopmentActorProfileId DevelopmentActorProfileId { get; set; }

    public ProductId ProductId { get; set; }
    public Product? Product { get; set; }

    public string? Description { get; set; }
}
