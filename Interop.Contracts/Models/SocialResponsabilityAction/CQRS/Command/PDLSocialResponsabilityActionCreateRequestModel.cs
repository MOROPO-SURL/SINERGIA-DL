using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Image.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Location.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.SocialResponsabilityAction.CQRS.Command;

public record PDLSocialResponsabilityActionCreateRequestModel(
    Guid OwnerId,
    string Title,
    DateTime At,
    IEnumerable<LocationCreateRequestModel> InLocations,
    IEnumerable<Guid> LinkLocationIds,
    IEnumerable<ImageCreateRequestModel> Images,
    Guid? DemandId,
    string? Description = null);