using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivities.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Locations.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.DTOs;

public record LegalOwnedPDLDevelopmentActorProfileDetailDto(
    Guid Id, 
    OrganizationBasicDto Owner, 
    string FiscalIdentificationCode,
    DateOnly BornAt,
    PDLModalityBasicDto Modality,
    EconomicActivityBasicDto MainEconomicActivity,
    IEnumerable<EconomicActivityBasicDto> SecoundaryEconomicActivities,
    LocationDetailDto MainLocation,
    IEnumerable<LocationDetailDto> CommercialLocations,
    OrganizationBasicDto Holder,
    string? About = null) : IDetailDto;