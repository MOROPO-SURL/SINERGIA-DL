using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Create;

public record SRLDevelopmentActorProfileCreateCommand(
    Guid Id,
    bool IsEnabled,
    Guid OwnerId,
    string FiscalIdentificationCode,
    int MainEconomicActivityId,
    IEnumerable<int> SecoundaryEconomicActivities,        
    string? About = null) : ICreateCommand<SRLDevelopmentActorProfileDetailDto>;