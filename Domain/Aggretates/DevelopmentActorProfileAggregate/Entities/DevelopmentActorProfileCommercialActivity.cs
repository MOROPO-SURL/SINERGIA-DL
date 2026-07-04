using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ProductAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ProductAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Entities;

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
