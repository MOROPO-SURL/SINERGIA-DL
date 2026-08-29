using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivities.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Locations.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.DTOs;

public record SRLDevelopmentActorProfileDetailDto(
    Guid Id, 
    OrganizationBasicDto Owner, 
    string FiscalIdentificationCode,
    DateOnly BornAt,
    EconomicActivityBasicDto MainEconomicActivity,
    IEnumerable<EconomicActivityBasicDto> SecoundaryEconomicActivities,
    LocationDetailDto MainLocation,
    IEnumerable<LocationDetailDto> CommercialLocations,
    IEnumerable<OrganizationBasicDto> OrganizationPartners,
    IEnumerable<PersonBasicDto> PersonPartners,
    string? About = null) : IDetailDto;