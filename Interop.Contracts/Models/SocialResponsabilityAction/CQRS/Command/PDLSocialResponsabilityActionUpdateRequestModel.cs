using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Image.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Location.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.SocialResponsabilityAction.CQRS.Command;

public record PDLSocialResponsabilityActionUpdateRequestModel(
    Guid Id,
    string Title,
    DateTime At,
    IEnumerable<LocationCreateRequestModel> InLocations,
    IEnumerable<Guid> LinkLocationIds,
    IEnumerable<Guid> UnlinkLocationIds,
    IEnumerable<ImageCreateRequestModel> InImages,
    IEnumerable<Guid> OutImageIds,
    Guid? DemandId,
    string? Description = null);