namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.CQRS.Command;

public record SRLDevelopmentActorProfileCreateRequestModel(
    Guid Id,
    Guid OwnerId,
    int MainEconomicActivityId,
    IEnumerable<int> SecoundaryEconomicActivities,
    string? About = null);