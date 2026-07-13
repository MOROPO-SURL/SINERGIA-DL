using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ProductAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ProductAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Entities;

public sealed class DevelopmentActorProfileProductionActivity : AbstractEntity<DevelopmentActorProfileProductionActivityId, Guid>
{
    private DevelopmentActorProfileProductionActivity() : base(default) { }

    public DevelopmentActorProfileProductionActivity(DevelopmentActorProfileProductionActivityId id) : base(id)
    {
    }

    public DevelopmentActorProfileId DevelopmentActorProfileId { get; set; }

    public ProductId ProductId { get; set; }
    public Product? Product { get; set; }

    public string? Description { get; set; }
}
