namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.CQRS.Command;

public record SRLDevelopmentActorProfileCreateRequestModel(
    Guid Id,
    Guid OwnerId,
    string FiscalIdentificationCode,
    int MainEconomicActivityId,
    IEnumerable<int> SecoundaryEconomicActivities,
    string? About = null);