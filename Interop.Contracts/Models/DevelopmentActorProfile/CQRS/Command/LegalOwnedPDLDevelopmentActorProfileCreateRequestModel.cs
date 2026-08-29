using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Location.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.DevelopmentActorProfile.CQRS.Command;

public record LegalOwnedPDLDevelopmentActorProfileCreateRequestModel(
    Guid Id,
    Guid OwnerId,
    string FiscalIdentificationCode,
    DateOnly BornAt,
    Guid ModalityId,
    int MainEconomicActivityId,
    IEnumerable<int> SecoundaryEconomicActivityIds,
    Guid MainLocationId,
    IEnumerable<LocationCreateRequestModel> InLocations,
    IEnumerable<Guid> LinkLocationIds,
    Guid HolderId,
    string? About = null);