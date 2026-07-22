namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.CQRS.Command;

public record SRLDevelopmentActorProfileCreateRequestModel(
    Guid Id,
    Guid OwnerId,
    string FiscalIdentificationCode,
    DateOnly BornAt,
    int MainEconomicActivityId,
    IEnumerable<int> SecoundaryEconomicActivityIds,
    IEnumerable<Guid> OrganizationPartnerIds,
    IEnumerable<Guid> PersonPartnerIds,
    string? About = null);