using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.LocationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.LocationAggregate.Values;
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
    protected readonly List<DevelopmentActorProfileLocationBridge> locationBridges = [];

    protected AbstractDevelopmentActorProfile() : base(new DevelopmentActorProfileId(default)) { }

    public AbstractDevelopmentActorProfile(DevelopmentActorProfileId id, bool isArchived, bool isEnabled, OrganizationId ownerId, string fiscalIdentificationCode, DateOnly bornAt, EconomicActivityId mainEconomicActivityId, LocationId mainLocationId, IEnumerable<DevelopmentActorProfileEconomicActivityBridge> secoundaryEconomicActivityBridges, IEnumerable<DevelopmentActorProfileLocationBridge> locationBridges, IEnumerable<DevelopmentActorProfileProductionActivity> productionActivities, IEnumerable<DevelopmentActorProfileCommercialActivity> commercialActivities, IEnumerable<DevelopmentActorProfileServicingActivity> servicingActivities, string? About = null, Organization? owner = null, EconomicActivity? mainEconomicActivity = null, Location? mainLocation = null) : base(id)
    {
        IsArchived = isArchived;
        IsEnabled = isEnabled;
        OwnerId = ownerId;
        FiscalIdentificationCode = fiscalIdentificationCode;
        BornAt = bornAt;
        MainEconomicActivityId = mainEconomicActivityId;
        MainLocationId = mainLocationId;

        this.secoundaryEconomicActivityBridges = [.. secoundaryEconomicActivityBridges];
        this.locationBridges = [.. locationBridges];
        this.productionActivities = [.. productionActivities];
        this.commercialActivities = [.. commercialActivities];
        this.servicingActivities = [.. servicingActivities];

        Owner = owner;
        MainEconomicActivity = mainEconomicActivity;
        MainLocation = mainLocation;
    }

    public bool IsArchived { get; set; }

    public bool IsEnabled { get; set; }

    public OrganizationId OwnerId { get; set; }
    public Organization? Owner { get; set; }

    public string FiscalIdentificationCode { get; set; } = null!;

    public DateOnly BornAt { get; set; }

    public EconomicActivityId MainEconomicActivityId { get; set; }
    public EconomicActivity? MainEconomicActivity { get; set; }

    public LocationId MainLocationId { get; set; }
    public Location? MainLocation { get; set; }

    public IReadOnlyList<DevelopmentActorProfileLocationBridge> LocationBridges => [.. locationBridges];

    public IReadOnlyList<DevelopmentActorProfileEconomicActivityBridge> SecoundaryEconomicActivityBridges => [.. secoundaryEconomicActivityBridges];

    public IReadOnlyList<DevelopmentActorProfileProductionActivity> ProductionActivities => [.. productionActivities];

    public IReadOnlyList<DevelopmentActorProfileCommercialActivity> CommercialActivities => [.. commercialActivities];

    public IReadOnlyList<DevelopmentActorProfileServicingActivity> ServicingActivities => [.. servicingActivities];

    public string? About { get; set; }

    public void LinkLocationById(LocationId locationId) => locationBridges.Add(new DevelopmentActorProfileLocationBridge(Id, locationId));

    public void RemoveLocationBridge(DevelopmentActorProfileLocationBridge bridge) => locationBridges.Remove(bridge);

    public void LinkSecoundaryEconomicActivityById(EconomicActivityId economicActivityId) => secoundaryEconomicActivityBridges.Add(new DevelopmentActorProfileEconomicActivityBridge(Id, economicActivityId));

    public void RemoveSecoundaryEconomicActivityBridge(DevelopmentActorProfileEconomicActivityBridge bridge) => secoundaryEconomicActivityBridges.Remove(bridge);

    public void AddProductionActivity(DevelopmentActorProfileProductionActivity entity) => productionActivities.Add(entity);

    public void RemoveProductionActivity(DevelopmentActorProfileProductionActivity entity) => productionActivities.Remove(entity);

    public void AddCommercialActivity(DevelopmentActorProfileCommercialActivity entity) => commercialActivities.Add(entity);

    public void RemoveCommercialActivity(DevelopmentActorProfileCommercialActivity entity) => commercialActivities.Remove(entity);

    public void AddProductionActivity(DevelopmentActorProfileServicingActivity entity) => servicingActivities.Add(entity);

    public void RemoveProductionActivity(DevelopmentActorProfileServicingActivity entity) => servicingActivities.Remove(entity);
}
