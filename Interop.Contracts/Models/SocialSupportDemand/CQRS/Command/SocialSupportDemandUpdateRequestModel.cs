using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Image.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialSupportDemand.CQRS.Command.Clipped;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialSupportDemand.CQRS.Command;

public record SocialSupportDemandUpdateRequestModel(
    Guid Id,
    string Title,
    int Priority,
    bool IsEnabled,
    IEnumerable<LocationCreateClippedRequestModel> InLocations,
    IEnumerable<LocationUpdateClippedRequestModel> PatchLocations,
    IEnumerable<Guid> OutLocationIds,
    IEnumerable<ImageCreateRequestModel> InImages,
    IEnumerable<Guid> OutImageIds,
    DateTime? StartAt = null,
    DateTime? EndAt = null,
    string? Description = null);