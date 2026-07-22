using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PDLModalityAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PDLModalityAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate;

public sealed class LegalOwnedPDLDevelopmentActorProfile : Abstractions.AbstractPDLDevelopmentActorProfile
{
    private LegalOwnedPDLDevelopmentActorProfile() { }

    public LegalOwnedPDLDevelopmentActorProfile(
        DevelopmentActorProfileId id, 
        bool isArchived, 
        bool isEnabled, 
        OrganizationId ownerId,
        string fiscalIdentificationCode,
        DateOnly bornAt,
        PDLModalityId modalityId,
        EconomicActivityId mainEconomicActivityId, 
        IEnumerable<DevelopmentActorProfileEconomicActivityBridge> secoundaryEconomicActivityBridges, 
        IEnumerable<DevelopmentActorProfileProductionActivity> productionActivities, 
        IEnumerable<DevelopmentActorProfileCommercialActivity> commercialActivities, 
        IEnumerable<DevelopmentActorProfileServicingActivity> servicingActivities,
        OrganizationId holderOrganizationId,
        string? About = null, 
        Organization? owner = null,
        PDLModality? modality = null,
        EconomicActivity? mainEconomicActivity = null,
        Organization? titular = null) : base(id, isArchived, isEnabled, ownerId, fiscalIdentificationCode, bornAt, modalityId, mainEconomicActivityId, secoundaryEconomicActivityBridges, productionActivities, commercialActivities, servicingActivities, About, owner, modality, mainEconomicActivity)
    {
        HolderOrganizationId = holderOrganizationId;

        Holder = titular;
    }

    public OrganizationId HolderOrganizationId { get; set; }
    public Organization? Holder { get; set; }
}