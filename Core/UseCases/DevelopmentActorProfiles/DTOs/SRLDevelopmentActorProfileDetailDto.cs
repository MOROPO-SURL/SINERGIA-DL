using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.DTOs;

public record SRLDevelopmentActorProfileDetailDto(
    Guid Id, 
    OrganizationBasicDto Owner, 
    string FiscalIdentificationCode,
    DateOnly BornAt,
    EconomicActivityBasicDto MainEconomicActivity,
    IEnumerable<EconomicActivityBasicDto> SecoundaryEconomicActivities,
    IEnumerable<OrganizationBasicDto> OrganizationPartners,
    IEnumerable<PersonBasicDto> PersonPartners,
    string? About = null) : IDetailDto;