using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Location.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.DevelopmentActorProfile.CQRS.Command;

public record SRLDevelopmentActorProfileUpdateRequestModel(
    Guid Id,
    string FiscalIdentificationCode,
    DateOnly BornAt,
    int MainEconomicActivityId,
    IEnumerable<int> InSecoundaryEconomicActivityIds,
    IEnumerable<int> OutSecoundaryEconomicActivityIds,
    Guid MainLocationId,
    IEnumerable<LocationCreateRequestModel> InLocations,
    IEnumerable<Guid> LinkLocationIds,
    IEnumerable<Guid> UnlinkLocationIds,
    IEnumerable<Guid> InOrganizationPartnerIds,
    IEnumerable<Guid> OutOrganizationPartnerIds,
    IEnumerable<Guid> InPersonPartnerIds,
    IEnumerable<Guid> OutPersonPartnerIds,
    string? About = null);
