using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.CQRS.Command.Update;

public record OrganizationKindUpdateCommand(
    Guid Id, 
    string Name, 
    bool IsEnabled,
    int Priority,
    DevelopmentActorProfileKind? DevelopmentActorProfileKind = null,
    string? Description = null) : IUpdateCommand<Guid, DTOs.OrganizationKindDetailDto>;