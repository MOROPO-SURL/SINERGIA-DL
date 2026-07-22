namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.CQRS.Command;

public record SRLDevelopmentActorProfileUpdateRequestModel(
    Guid Id,
    string FiscalIdentificationCode,
    DateOnly BornAt,
    int MainEconomicActivityId,
    IEnumerable<int> InSecoundaryEconomicActivityIds,
    IEnumerable<int> OutSecoundaryEconomicActivityIds,
    IEnumerable<Guid> InOrganizationPartnerIds,
    IEnumerable<Guid> OutOrganizationPartnerIds,
    IEnumerable<Guid> InPersonPartnerIds,
    IEnumerable<Guid> OutPersonPartnerIds,
    string? About = null);
