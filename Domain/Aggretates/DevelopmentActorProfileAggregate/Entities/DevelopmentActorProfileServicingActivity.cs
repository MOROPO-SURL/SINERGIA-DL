using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ServiceAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ServiceAggregate;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Entities;

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
