namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.CQRS.Command;

public record SRLDevelopmentActorProfileUpdateRequestModel(
    Guid Id,
    Guid OwnerId,
    string FiscalIdentificationCode,
    int MainEconomicActivityId,
    IEnumerable<int> InSecoundaryEconomicActivities,
    IEnumerable<int> OutSecoundaryEconomicActivities,
    string? About = null);
