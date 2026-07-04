using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Update;

public record SRLDevelopmentActorProfileUpdateCommand(
    Guid Id,
    bool IsArchived,
    bool IsEnabled,
    Guid OwnerId,
    int MainEconomicActivityId,
    IEnumerable<int> InSecoundaryEconomicActivities,
    IEnumerable<int> OutSecoundaryEconomicActivities,
    string? About = null) : IUpdateCommand<Guid, SRLDevelopmentActorProfileDetailDto>;