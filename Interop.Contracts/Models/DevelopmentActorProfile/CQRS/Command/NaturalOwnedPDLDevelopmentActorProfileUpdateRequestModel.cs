using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Location.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.DevelopmentActorProfile.CQRS.Command;

public record NaturalOwnedPDLDevelopmentActorProfileUpdateRequestModel(
    Guid Id,
    string FiscalIdentificationCode,
    DateOnly BornAt,
    Guid ModalityId,
    int MainEconomicActivityId,
    IEnumerable<int> InSecoundaryEconomicActivityIds,
    IEnumerable<int> OutSecoundaryEconomicActivityIds,
    Guid MainLocationId,
    IEnumerable<LocationCreateRequestModel> InLocations,
    IEnumerable<Guid> LinkLocationIds,
    IEnumerable<Guid> UnlinkLocationIds,
    Guid HolderId,
    string? About = null);
