using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate;

public sealed class SRLDevelopmentActorProfile : Abstractions.AbstractDevelopmentActorProfile
{
    private readonly List<SRLDevelopmentActorProfileOrganizationBridge> organizationBridges = [];
    private readonly List<SRLDevelopmentActorProfilePersonBridge> personBridges = [];

    private SRLDevelopmentActorProfile() { }

    public SRLDevelopmentActorProfile(
        DevelopmentActorProfileId id, 
        bool isArchived, 
        bool isEnabled, 
        OrganizationId ownerId,
        string fiscalIdentificationCode,
        DateOnly bornAt,
        EconomicActivityId mainEconomicActivityId, 
        IEnumerable<DevelopmentActorProfileEconomicActivityBridge> secoundaryEconomicActivityBridges, 
        IEnumerable<DevelopmentActorProfileProductionActivity> productionActivities, 
        IEnumerable<DevelopmentActorProfileCommercialActivity> commercialActivities, 
        IEnumerable<DevelopmentActorProfileServicingActivity> servicingActivities,
        IEnumerable<SRLDevelopmentActorProfileOrganizationBridge> organizationBridges,
        IEnumerable<SRLDevelopmentActorProfilePersonBridge> personBridges,
        string? About = null, 
        Organization? owner = null, 
        EconomicActivity? mainEconomicActivity = null) : base(id, isArchived, isEnabled, ownerId, fiscalIdentificationCode, bornAt, mainEconomicActivityId, secoundaryEconomicActivityBridges, productionActivities, commercialActivities, servicingActivities, About, owner, mainEconomicActivity)
    {
        this.organizationBridges = [.. organizationBridges];
        this.personBridges = [.. personBridges];
    }

    public IReadOnlyList<SRLDevelopmentActorProfileOrganizationBridge> OrganizationBridges => [.. organizationBridges];

    public IReadOnlyList<SRLDevelopmentActorProfilePersonBridge> PersonBridges => [.. personBridges];

    public void LinkOrganizationById(OrganizationId organizationId) => organizationBridges.Add(new SRLDevelopmentActorProfileOrganizationBridge(Id, organizationId));

    public void UnlinkOrganizationById(OrganizationId organizationId) => organizationBridges.Remove(organizationBridges.First(bridge => bridge.LinkedId == organizationId));

    public void LinkPersonById(PersonId personId) => personBridges.Add(new SRLDevelopmentActorProfilePersonBridge(Id, personId));

    public void UnlinkPersonById(PersonId personId) => personBridges.Remove(personBridges.First(bridge => bridge.LinkedId == personId));
}
