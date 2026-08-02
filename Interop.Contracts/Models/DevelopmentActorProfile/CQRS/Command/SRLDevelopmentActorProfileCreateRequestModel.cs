using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Location.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.CQRS.Command;

public record SRLDevelopmentActorProfileCreateRequestModel(
    Guid Id,
    Guid OwnerId,
    string FiscalIdentificationCode,
    DateOnly BornAt,
    int MainEconomicActivityId,
    IEnumerable<int> SecoundaryEconomicActivityIds,
    Guid MainLocationId,
    IEnumerable<LocationCreateRequestModel> InLocations,
    IEnumerable<Guid> LinkLocationIds,
    IEnumerable<Guid> OrganizationPartnerIds,
    IEnumerable<Guid> PersonPartnerIds,
    string? About = null);