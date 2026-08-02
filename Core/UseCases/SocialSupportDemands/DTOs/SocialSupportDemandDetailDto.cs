using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Locations.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.DTOs;

public record SocialSupportDemandDetailDto(
    Guid Id, 
    string Title, 
    int Priority, 
    bool IsEnabled, 
    bool IsArchived, 
    IEnumerable<LocationDetailDto> Locations, 
    IEnumerable<ImageBasicDto> Images, 
    DateTime? StartAt = null, 
    DateTime? EndAt = null, string? Description = null) : IDetailDto;