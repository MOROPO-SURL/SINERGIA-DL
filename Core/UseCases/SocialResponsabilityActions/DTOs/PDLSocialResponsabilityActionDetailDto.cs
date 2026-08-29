using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Locations.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialResponsabilityActions.DTOs;

public record PDLSocialResponsabilityActionDetailDto(
    Guid Id, 
    OrganizationBasicDto Organization,
    string Title,
    DateTime At,
    IEnumerable<LocationDetailDto> Locations,
    IEnumerable<ImageBasicDto> Images,
    SocialSupportDemandBasicDto? Demand = null,
    string? Description = null) : IDetailDto;