using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Update;

public record SRLDevelopmentActorProfileUpdateCommand(
    Guid Id,
    bool IsArchived,
    bool IsEnabled,
    Guid OwnerId,
    string FiscalIdentificationCode,
    DateOnly BornAt,
    int MainEconomicActivityId,
    IEnumerable<int> InSecoundaryEconomicActivityIds,
    IEnumerable<int> OutSecoundaryEconomicActivityIds,
    IEnumerable<Guid> InOrganizationPartnerIds,
    IEnumerable<Guid> OutOrganizationPartnerIds,
    IEnumerable<Guid> InPersonPartnerIds,
    IEnumerable<Guid> OutPersonPartnerIds,
    string? About = null) : IUpdateCommand<Guid, SRLDevelopmentActorProfileDetailDto>;