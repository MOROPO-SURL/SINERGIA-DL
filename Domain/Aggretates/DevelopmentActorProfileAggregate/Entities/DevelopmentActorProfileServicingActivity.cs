using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ServiceAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ServiceAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Entities;

public sealed class DevelopmentActorProfileServicingActivity : AbstractEntity<DevelopmentActorProfileServicingActivityId, Guid>
{
    private DevelopmentActorProfileServicingActivity() : base(default) { }

    public DevelopmentActorProfileServicingActivity(DevelopmentActorProfileServicingActivityId id, DevelopmentActorProfileId developmentActorProfileId, ServiceId serviceId, Service? service = null, string? description = null) : base(id)
    {
        DevelopmentActorProfileId = developmentActorProfileId;
        ServiceId = serviceId;
        Service = service;
        Description = description;
    }

    public DevelopmentActorProfileId DevelopmentActorProfileId { get; set; }

    public ServiceId ServiceId { get; set; }
    public Service? Service { get; set; }

    public string? Description { get; set; }
}
