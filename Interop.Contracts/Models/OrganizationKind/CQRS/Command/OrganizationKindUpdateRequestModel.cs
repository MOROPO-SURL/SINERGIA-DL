namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.OrganizationKind.CQRS.Command;

public record OrganizationKindUpdateRequestModel(Guid Id, string Name, string? Description = null);