using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Abstractions;

public abstract class AbstractDevelopmentActorProfile : AbstractEntity<DevelopmentActorProfileId, Guid>, IEnableableEntity<DevelopmentActorProfileId, Guid>, IArchivableEntity<DevelopmentActorProfileId, Guid>
{
    protected readonly List<DevelopmentActorProfileProductionActivity> productionActivities = [];
    protected readonly List<DevelopmentActorProfileCommercialActivity> commercialActivities = [];
    protected readonly List<DevelopmentActorProfileServicingActivity> servicingActivities = [];
    protected readonly List<DevelopmentActorProfileEconomicActivityBridge> secoundaryEconomicActivityBridges = [];

    protected AbstractDevelopmentActorProfile() : base(new DevelopmentActorProfileId(default)) { }

    public AbstractDevelopmentActorProfile(DevelopmentActorProfileId id, bool isArchived, bool isEnabled, OrganizationId ownerId, string fiscalIdentificationCode, EconomicActivityId mainEconomicActivityId, IEnumerable<DevelopmentActorProfileEconomicActivityBridge> secoundaryEconomicActivityBridges, IEnumerable<DevelopmentActorProfileProductionActivity> productionActivities, IEnumerable<DevelopmentActorProfileCommercialActivity> commercialActivities, IEnumerable<DevelopmentActorProfileServicingActivity> servicingActivities, string? About = null, Organization? owner = null, EconomicActivity? mainEconomicActivity = null) : base(id)
    {
        IsArchived = isArchived;
        IsEnabled = isEnabled;
        OwnerId = ownerId;
        FiscalIdentificationCode = fiscalIdentificationCode;
        MainEconomicActivityId = mainEconomicActivityId;

        this.secoundaryEconomicActivityBridges = [.. secoundaryEconomicActivityBridges];
        this.productionActivities = [.. productionActivities];
        this.commercialActivities = [.. commercialActivities];
        this.servicingActivities = [.. servicingActivities];

        Owner = owner;
        MainEconomicActivity = mainEconomicActivity;
    }

    public bool IsArchived { get; set; }

    public bool IsEnabled { get; set; }

    public OrganizationId OwnerId { get; set; }
    public Organization? Owner { get; set; }

    public string FiscalIdentificationCode { get; set; } = null!;

    public EconomicActivityId MainEconomicActivityId { get; set; }
    public EconomicActivity? MainEconomicActivity { get; set; }

    public IReadOnlyList<DevelopmentActorProfileEconomicActivityBridge> SecoundaryEconomicActivityBridges => [.. secoundaryEconomicActivityBridges];

    public IReadOnlyList<DevelopmentActorProfileProductionActivity> ProductionActivities => [.. productionActivities];

    public IReadOnlyList<DevelopmentActorProfileCommercialActivity> CommercialActivities => [.. commercialActivities];

    public IReadOnlyList<DevelopmentActorProfileServicingActivity> ServicingActivities => [.. servicingActivities];

    public string? About { get; set; }

    public void LinkSecoundaryEconomicActivityById(EconomicActivityId economicActivityId) => secoundaryEconomicActivityBridges.Add(new DevelopmentActorProfileEconomicActivityBridge(Id, economicActivityId));

    public void UnlinkSecoundaryEconomicActivityById(EconomicActivityId economicActivityId) => secoundaryEconomicActivityBridges.Remove(secoundaryEconomicActivityBridges.First(bridg => bridg.LinkedId == economicActivityId));

    public void AddProductionActivity(DevelopmentActorProfileProductionActivity entity) => productionActivities.Add(entity);

    public void RemoveProductionActivity(DevelopmentActorProfileProductionActivity entity) => productionActivities.Remove(entity);

    public void AddCommercialActivity(DevelopmentActorProfileCommercialActivity entity) => commercialActivities.Add(entity);

    public void RemoveCommercialActivity(DevelopmentActorProfileCommercialActivity entity) => commercialActivities.Remove(entity);

    public void AddProductionActivity(DevelopmentActorProfileServicingActivity entity) => servicingActivities.Add(entity);

    public void RemoveProductionActivity(DevelopmentActorProfileServicingActivity entity) => servicingActivities.Remove(entity);
}
