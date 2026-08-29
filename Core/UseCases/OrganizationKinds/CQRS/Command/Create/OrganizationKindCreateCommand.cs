using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKinds.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKinds.CQRS.Command.Create;

public record OrganizationKindCreateCommand(
    string Name, 
    bool IsEnabled,
    int Priority,
    DevelopmentActorProfileKind? DevelopmentActorProfileKind = null, 
    string? Description = null) : ICreateCommand<OrganizationKindDetailDto>;