using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Bridges;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Entities;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.EconomicActivityAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.EconomicActivityAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.LocationAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.LocationAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PDLModalityAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PDLModalityAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Abstractions;

public abstract class AbstractPDLDevelopmentActorProfile : AbstractDevelopmentActorProfile
{
    protected AbstractPDLDevelopmentActorProfile() { }

    public AbstractPDLDevelopmentActorProfile(
        DevelopmentActorProfileId id, 
        bool isArchived, 
        bool isEnabled, 
        OrganizationId ownerId,
        string fiscalIdentificationCode,
        DateOnly bornAt,
        PDLModalityId modalityId,
        EconomicActivityId mainEconomicActivityId, 
        LocationId mainLocationId, 
        IEnumerable<DevelopmentActorProfileEconomicActivityBridge> secoundaryEconomicActivityBridges,
        IEnumerable<DevelopmentActorProfileLocationBridge> locationBridges,
        IEnumerable<DevelopmentActorProfileProductionActivity> productionActivities, 
        IEnumerable<DevelopmentActorProfileCommercialActivity> commercialActivities, 
        IEnumerable<DevelopmentActorProfileServicingActivity> servicingActivities, 
        string? About = null, 
        Organization? owner = null, 
        PDLModality? modality = null,
        EconomicActivity? mainEconomicActivity = null, 
        Location? mainLocation = null) : base(id, isArchived, isEnabled, ownerId, fiscalIdentificationCode, bornAt, mainEconomicActivityId, mainLocationId, secoundaryEconomicActivityBridges, locationBridges, productionActivities, commercialActivities, servicingActivities, About, owner, mainEconomicActivity, mainLocation)
    {
        ModalityId = modalityId;
        Modality = modality;
    }

    public PDLModalityId ModalityId { get; set; }
    public PDLModality? Modality { get; set; }
}