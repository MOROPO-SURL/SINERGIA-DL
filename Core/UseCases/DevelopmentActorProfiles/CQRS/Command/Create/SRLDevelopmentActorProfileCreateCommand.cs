using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Locations.CQRS.Command.Create;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Create;

public record SRLDevelopmentActorProfileCreateCommand(
    Guid Id,
    bool IsEnabled,
    Guid OwnerId,
    string FiscalIdentificationCode,
    DateOnly BornAt,
    int MainEconomicActivityId,
    IEnumerable<int> SecoundaryEconomicActivityIds,  
    Guid MainLocationId,
    IEnumerable<LocationCreateCommand> InLocations,
    IEnumerable<Guid> LinkLocationIds,
    IEnumerable<Guid> OrganizationPartnerIds,
    IEnumerable<Guid> PersonPartnerIds,
    string? About = null) : ICreateCommand<SRLDevelopmentActorProfileDetailDto>;