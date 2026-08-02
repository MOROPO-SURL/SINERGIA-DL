using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.EconomicActivity.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Location.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.DTOs;

public record SRLDevelopmentActorProfileDetailDtoModel(
    Guid Id,
    OrganizationBasicDtoModel Owner,
    string FiscalIdentificationCode,
    DateOnly BornAt,
    EconomicActivityBasicDtoModel MainEconomicActivity,
    IEnumerable<EconomicActivityBasicDtoModel> SecoundaryEconomicActivities,
    LocationDetailDtoModel MainLocation,
    IEnumerable<LocationDetailDtoModel> CommercialLocations,
    IEnumerable<OrganizationBasicDtoModel> OrganizationPartners,
    IEnumerable<PersonBasicDtoModel> PersonPartners,
    string? About = null);