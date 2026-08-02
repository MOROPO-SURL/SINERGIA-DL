using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Locations.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.CQRS.Command.Create;

public record SocialSupportDemandCreateCommand(
    Guid Id, 
    string Title,
    int Priority, 
    bool IsEnabled,
    IEnumerable<LocationCreateCommand> InLocations,
    IEnumerable<Guid> LinkLocationIds,
    IEnumerable<ImageCreateCommand> Images,
    DateTime? StartAt = null,
    DateTime? EndAt = null,
    string? Description = null) : ICreateCommand<SocialSupportDemandDetailDto>;