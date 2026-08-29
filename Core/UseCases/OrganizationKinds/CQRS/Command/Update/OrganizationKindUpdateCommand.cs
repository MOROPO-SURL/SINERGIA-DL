using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKinds.CQRS.Command.Update;

public record OrganizationKindUpdateCommand(
    Guid Id, 
    string Name, 
    bool IsEnabled,
    int Priority,
    DevelopmentActorProfileKind? DevelopmentActorProfileKind = null,
    string? Description = null) : IUpdateCommand<Guid, DTOs.OrganizationKindDetailDto>;