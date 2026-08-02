using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Image.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Location.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialSupportDemand.CQRS.Command;

public record SocialSupportDemandUpdateRequestModel(
    Guid Id,
    string Title,
    int Priority,
    bool IsEnabled,
    IEnumerable<LocationCreateRequestModel> InLocations,
    IEnumerable<Guid> LinkLocationIds,
    IEnumerable<Guid> UnlinkLocationIds,
    IEnumerable<ImageCreateRequestModel> InImages,
    IEnumerable<Guid> OutImageIds,
    DateTime? StartAt = null,
    DateTime? EndAt = null,
    string? Description = null);