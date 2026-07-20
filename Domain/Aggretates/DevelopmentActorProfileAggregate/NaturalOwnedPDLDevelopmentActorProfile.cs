using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PDLModalityAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PDLModalityAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate;

public sealed class NaturalOwnedPDLDevelopmentActorProfile : Abstractions.AbstractPDLDevelopmentActorProfile
{
    private NaturalOwnedPDLDevelopmentActorProfile() { }

    public NaturalOwnedPDLDevelopmentActorProfile(
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
        PersonId holderPersonId,
        string? About = null, 
        Organization? owner = null,
        PDLModality? modality = null,
        EconomicActivity? mainEconomicActivity = null,
        Person? holder = null) : base(id, isArchived, isEnabled, ownerId, fiscalIdentificationCode, modalityId, mainEconomicActivityId, secoundaryEconomicActivityBridges, productionActivities, commercialActivities, servicingActivities, About, owner, modality, mainEconomicActivity)
    {
        HolderPersonId = holderPersonId;

        Holder = holder;
    }

    public PersonId HolderPersonId { get; set; }
    public Person? Holder { get; set; }
}
