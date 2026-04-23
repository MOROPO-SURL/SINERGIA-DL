namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.OrganizationKind.DTOs;

public record OrganizationKindDetailDtoModel(Guid Id, string Name, bool IsEnabled, string? Description = null);