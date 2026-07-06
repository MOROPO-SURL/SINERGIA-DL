namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.OrganizationKind.CQRS.Command;

public record OrganizationKindCreateRequestModel(
    string Name,
    Enumerations.DevelopmentActorProfileKind? DevelopmentActorProfileKind = null,
    string? Description = null);
