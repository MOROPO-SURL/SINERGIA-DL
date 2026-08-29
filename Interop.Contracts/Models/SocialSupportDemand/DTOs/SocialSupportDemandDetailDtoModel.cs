using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Image.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Location.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.SocialSupportDemand.DTOs;

public record SocialSupportDemandDetailDtoModel(
    Guid Id,
    string Title,
    int Priority,
    bool IsEnabled,
    bool IsArchived,
    IEnumerable<LocationDetailDtoModel> Locations,
    IEnumerable<ImageBasicDtoModel> Images,
    DateTime? StartAt = null,
    DateTime? EndAt = null, string? Description = null);