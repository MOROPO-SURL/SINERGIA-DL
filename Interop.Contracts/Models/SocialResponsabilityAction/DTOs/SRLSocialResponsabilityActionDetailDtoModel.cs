using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Image.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Location.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialSupportDemand.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialResponsabilityAction.DTOs;

public record SRLSocialResponsabilityActionDetailDtoModel(
    Guid Id,
    string Title,
    DateTime At,
    IEnumerable<LocationDetailDtoModel> Locations,
    IEnumerable<ImageBasicDtoModel> Images,
    SocialSupportDemandBasicDtoModel? Demand = null,
    string? Description = null);