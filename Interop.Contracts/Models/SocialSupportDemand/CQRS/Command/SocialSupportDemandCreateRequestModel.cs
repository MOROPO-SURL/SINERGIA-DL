using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Image.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialSupportDemand.CQRS.Command;

public record SocialSupportDemandCreateRequestModel(
    Guid Id,
    string Title,
    int Priority,
    bool IsEnabled,
    IEnumerable<Clipped.LocationCreateClippedRequestModel> Locations,
    IEnumerable<ImageCreateRequestModel> Images,
    DateTime? StartAt = null,
    DateTime? EndAt = null,
    string? Description = null);