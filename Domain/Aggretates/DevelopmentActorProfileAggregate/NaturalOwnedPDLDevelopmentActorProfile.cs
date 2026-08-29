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
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate;

public sealed class NaturalOwnedPDLDevelopmentActorProfile : Abstractions.AbstractPDLDevelopmentActorProfile
{
    private NaturalOwnedPDLDevelopmentActorProfile() { }

    public NaturalOwnedPDLDevelopmentActorProfile(
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
        PersonId holderPersonId,
        string? About = null, 
        Organization? owner = null,
        PDLModality? modality = null,
        EconomicActivity? mainEconomicActivity = null, 
        Location? mainLocation = null,
        Person? holder = null) : base(id, isArchived, isEnabled, ownerId, fiscalIdentificationCode, bornAt, modalityId, mainEconomicActivityId, mainLocationId, secoundaryEconomicActivityBridges, locationBridges, productionActivities, commercialActivities, servicingActivities, About, owner, modality, mainEconomicActivity, mainLocation)
    {
        HolderPersonId = holderPersonId;

        Holder = holder;
    }

    public PersonId HolderPersonId { get; set; }
    public Person? Holder { get; set; }
}
