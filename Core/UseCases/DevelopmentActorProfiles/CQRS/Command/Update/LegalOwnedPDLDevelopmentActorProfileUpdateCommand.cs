using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Locations.CQRS.Command.Create;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Update;

public record LegalOwnedPDLDevelopmentActorProfileUpdateCommand(
    Guid Id,
    bool IsArchived,
    bool IsEnabled,
    Guid OwnerId,
    string FiscalIdentificationCode,
    DateOnly BornAt,
    int MainEconomicActivityId,
    IEnumerable<int> InSecoundaryEconomicActivityIds,
    IEnumerable<int> OutSecoundaryEconomicActivityIds,
    Guid MainLocationId,
    IEnumerable<LocationCreateCommand> InLocations,
    IEnumerable<Guid> LinkLocationIds,
    IEnumerable<Guid> UnlinkLocationIds,
    Guid HolderId,
    string? About = null) : IUpdateCommand<Guid, LegalOwnedPDLDevelopmentActorProfileDetailDto>;