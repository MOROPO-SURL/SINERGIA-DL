using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate;

public sealed class LegalOwnedPDLDevelopmentActorProfile : Abstractions.AbstractPDLDevelopmentActorProfile
{
    private LegalOwnedPDLDevelopmentActorProfile() { }

    public LegalOwnedPDLDevelopmentActorProfile(
        DevelopmentActorProfileId id, 
        bool isArchived, 
        bool isEnabled, 
        OrganizationId ownerId, 
        EconomicActivityId mainEconomicActivityId, 
        IEnumerable<DevelopmentActorProfileEconomicActivityBridge> secoundaryEconomicActivityBridges, 
        IEnumerable<DevelopmentActorProfileProductionActivity> productionActivities, 
        IEnumerable<DevelopmentActorProfileCommercialActivity> commercialActivities, 
        IEnumerable<DevelopmentActorProfileServicingActivity> servicingActivities,
        OrganizationId titularOrganizationId,
        string? About = null, 
        Organization? organization = null, 
        EconomicActivity? mainEconomicActivity = null,
        Organization? titular = null) : base(id, isArchived, isEnabled, ownerId, mainEconomicActivityId, secoundaryEconomicActivityBridges, productionActivities, commercialActivities, servicingActivities, About, organization, mainEconomicActivity)
    {
        TitularOrganizationId = titularOrganizationId;

        Titular = titular;
    }

    public OrganizationId TitularOrganizationId { get; set; }
    public Organization? Titular { get; set; }
}