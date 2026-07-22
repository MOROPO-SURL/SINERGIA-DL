using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Create;

public record SRLDevelopmentActorProfileCreateCommand(
    Guid Id,
    bool IsEnabled,
    Guid OwnerId,
    string FiscalIdentificationCode,
    DateOnly BornAt,
    int MainEconomicActivityId,
    IEnumerable<int> SecoundaryEconomicActivityIds,  
    IEnumerable<Guid> OrganizationPartnerIds,
    IEnumerable<Guid> PersonPartnerIds,
    string? About = null) : ICreateCommand<SRLDevelopmentActorProfileDetailDto>;