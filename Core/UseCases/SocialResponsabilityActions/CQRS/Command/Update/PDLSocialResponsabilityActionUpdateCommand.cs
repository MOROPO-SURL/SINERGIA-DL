using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Locations.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialResponsabilityActions.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialResponsabilityActions.CQRS.Command.Update;

public record PDLSocialResponsabilityActionUpdateCommand(
    Guid Id,
    string Title,
    DateTime At,
    IEnumerable<LocationCreateCommand> InLocations,
    IEnumerable<Guid> LinkLocationIds,
    IEnumerable<Guid> UnlinkLocationIds,
    IEnumerable<ImageCreateCommand> InImages,
    IEnumerable<Guid> OutImageIds,
    Guid? DemandId,
    string? Description = null) : IUpdateCommand<Guid, PDLSocialResponsabilityActionDetailDto>;