using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Locations.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PDLModalities.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.DTOs;

public record NaturalOwnedPDLDevelopmentActorProfileDetailDto(
    Guid Id, 
    OrganizationBasicDto Owner, 
    string FiscalIdentificationCode,
    DateOnly BornAt,
    PDLModalityBasicDto Modality,
    EconomicActivityBasicDto MainEconomicActivity,
    IEnumerable<EconomicActivityBasicDto> SecoundaryEconomicActivities,
    LocationDetailDto MainLocation,
    IEnumerable<LocationDetailDto> CommercialLocations,
    PersonBasicDto Holder,
    string? About = null) : IDetailDto;