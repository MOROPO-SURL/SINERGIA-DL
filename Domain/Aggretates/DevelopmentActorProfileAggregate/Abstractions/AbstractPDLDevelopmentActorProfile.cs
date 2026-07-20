using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PDLModalityAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PDLModalityAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Abstractions;

public abstract class AbstractPDLDevelopmentActorProfile : AbstractDevelopmentActorProfile
{
    protected AbstractPDLDevelopmentActorProfile() { }

    public AbstractPDLDevelopmentActorProfile(
        DevelopmentActorProfileId id, 
        bool isArchived, 
        bool isEnabled, 
        OrganizationId ownerId,
        string fiscalIdentificationCode,
        PDLModalityId modalityId,
        EconomicActivityId mainEconomicActivityId, 
        IEnumerable<DevelopmentActorProfileEconomicActivityBridge> secoundaryEconomicActivityBridges, 
        IEnumerable<DevelopmentActorProfileProductionActivity> productionActivities, 
        IEnumerable<DevelopmentActorProfileCommercialActivity> commercialActivities, 
        IEnumerable<DevelopmentActorProfileServicingActivity> servicingActivities, 
        string? About = null, 
        Organization? owner = null, 
        PDLModality? modality = null,
        EconomicActivity? mainEconomicActivity = null) : base(id, isArchived, isEnabled, ownerId, fiscalIdentificationCode, mainEconomicActivityId, secoundaryEconomicActivityBridges, productionActivities, commercialActivities, servicingActivities, About, owner, mainEconomicActivity)
    {
        ModalityId = modalityId;
        Modality = modality;
    }

    public PDLModalityId ModalityId { get; set; }
    public PDLModality? Modality { get; set; }
}