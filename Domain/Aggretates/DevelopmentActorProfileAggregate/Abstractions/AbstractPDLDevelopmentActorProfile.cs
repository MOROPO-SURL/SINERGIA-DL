using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Abstractions;

public abstract class AbstractPDLDevelopmentActorProfile : AbstractDevelopmentActorProfile
{
    protected AbstractPDLDevelopmentActorProfile() { }

    public AbstractPDLDevelopmentActorProfile(
        DevelopmentActorProfileId id, 
        bool isArchived, 
        bool isEnabled, 
        OrganizationId ownerId, 
        EconomicActivityId mainEconomicActivityId, 
        IEnumerable<DevelopmentActorProfileEconomicActivityBridge> secoundaryEconomicActivityBridges, 
        IEnumerable<DevelopmentActorProfileProductionActivity> productionActivities, 
        IEnumerable<DevelopmentActorProfileCommercialActivity> commercialActivities, 
        IEnumerable<DevelopmentActorProfileServicingActivity> servicingActivities, 
        string? About = null, 
        Organization? organization = null, 
        EconomicActivity? mainEconomicActivity = null) : base(id, isArchived, isEnabled, ownerId, mainEconomicActivityId, secoundaryEconomicActivityBridges, productionActivities, commercialActivities, servicingActivities, About, organization, mainEconomicActivity)
    {
    }
}