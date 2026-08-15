using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Locations.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.DTOs;

public record SRLSocialResponsabilityActionDetailDto(
    Guid Id, 
    OrganizationBasicDto Organization,
    string Title,
    DateTime At,
    IEnumerable<LocationDetailDto> Locations,
    IEnumerable<ImageBasicDto> Images,
    SocialSupportDemandBasicDto? Demand = null,
    string? Description = null) : IDetailDto;