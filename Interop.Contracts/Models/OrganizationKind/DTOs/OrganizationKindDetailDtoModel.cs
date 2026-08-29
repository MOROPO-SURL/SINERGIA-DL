namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.OrganizationKind.DTOs;

public record OrganizationKindDetailDtoModel(
    Guid Id, 
    string Name, 
    bool IsEnabled,
    Enumerations.DevelopmentActorProfileKind? DevelopmentActorProfileKind = null,
    string? Description = null);