using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Locations.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.CQRS.Command.Update;

public record SocialSupportDemandUpdateCommand(
    Guid Id,
    string Title,
    int Priority,
    bool IsEnabled,
    IEnumerable<LocationCreateCommand> InLocations,
    IEnumerable<Guid> LinkLocationIds,
    IEnumerable<Guid> UnlinkLocationIds,
    IEnumerable<ImageCreateCommand> InImages,
    IEnumerable<Guid> OutImageIds,
    DateTime? StartAt = null,
    DateTime? EndAt = null,
    string? Description = null) : IUpdateCommand<Guid, SocialSupportDemandDetailDto>;