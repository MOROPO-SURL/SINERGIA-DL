using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Image.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Location.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.SocialSupportDemand.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.SocialResponsabilityAction.DTOs;

public record SRLSocialResponsabilityActionDetailDtoModel(
    Guid Id, 
    OrganizationBasicDtoModel Organization,
    string Title,
    DateTime At,
    IEnumerable<LocationDetailDtoModel> Locations,
    IEnumerable<ImageBasicDtoModel> Images,
    SocialSupportDemandBasicDtoModel? Demand = null,
    string? Description = null);