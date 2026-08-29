namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.OrganizationKind.CQRS.Command;

public record OrganizationKindUpdateRequestModel(
    Guid Id, 
    string Name,
    Enumerations.DevelopmentActorProfileKind? DevelopmentActorProfileKind = null,
    string? Description = null);